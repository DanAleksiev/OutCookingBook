using CookBook.Areas.Admin.Contracts;
using CookBook.Areas.Admin.Models;
using CookBook.Infrastructures.Data.Common;
using CookBook.Infrastructures.Data.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Areas.Admin.Services
    {
    public class AdminService : IAdminService
        {
        private readonly IRepository repository;
        private readonly UserManager<IdentityUser> userManager;

        public AdminService(IRepository _repository, UserManager<IdentityUser> _userManager)
            {
            repository = _repository;
            userManager = _userManager;
            }

        public async Task<string> Ban(BanFormModel model)
            {
            var userId = await GetUserId(model.Username);
            if (userId != null)
                {
                bool exist = await repository
                    .AllReadOnly<BanedUsers>()
                    .AnyAsync(u =>
                    u.IsBaned == true
                    && u.UserId == userId);

                if (exist)
                    {
                    return "User already banned";
                    }

                var userInfo = new BanedUsers()
                    {
                    UserId = userId,
                    Reason = model.Reason,
                    IsBaned = true,
                    BanDate = DateTime.Now,
                    Lenght = model.Lenght
                    };

                await repository.AddAsync(userInfo);
                await repository.SaveChangesAsync();
                return "Success";
                }
            else return "User does not exist!";
            }

        public async Task ChangeRole(string username, string role)
            {
            var userId = await GetUserId(username);

            var user = await userManager.FindByIdAsync(userId);

            if (user != null && role != null)
                {
                await userManager.AddToRoleAsync(user, role);
                }
            }

        public async Task<string> GetRoleId(string role)
            {
            var roleId = await repository
                .AllReadOnly<IdentityRole>()
                .Where(r => r.Name == role)
                .AsNoTracking()
                .FirstAsync();

            return roleId.Id;
            }

        public async Task<string> GetUserId(string username)
            {
            var user = await repository
                .All<IdentityUser>()
                .Where(u => u.UserName == username)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return user.Id;
            }

        public async Task<string> LiftBan(LiftBanModel model)
            {
            var userId = await GetUserId(model.Username);
            if (userId != null)
                {
                var exist = await repository
                    .AllReadOnly<BanedUsers>()
                    .Where(u => u.UserId == userId)
                    .Where(u => u.IsBaned == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (exist != null)
                    {
                    var user = await repository
                        .GetByIdAsync<BanedUsers>(exist.Id);
                    user.IsBaned = false;
                    await repository.SaveChangesAsync();
                    return "Success";
                    }

                return "Ueser is not baned";
                }
            else return "User does not exist!";
            }

        public async Task<bool> UserExist(string username)
            {
            return await repository
                .AllReadOnly<IdentityUser>()
                .AsNoTracking()
                .AnyAsync(u => u.UserName == username);
            }
        }
    }
