using CookBook.Areas.Admin.Contracts;
using CookBook.Core.Models.Admin;
using CookBook.Infrastructures.Data.Common;
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

        public async Task<bool> Ban(string username)
            {
            var userId = await GetUserId(username);
            if (userId != null)
                {
                var user = await repository.GetByIdAsync<IdentityUser>(userId);
                user.LockoutEnabled = true;
                return true;
                }
            else return false;
            }

        public async Task ChangeRole(string username, string role)
            {
            //var userId = await repository
            //    .AllReadOnly<IdentityUser>()
            //    .Where(u => u.UserName == username)
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync();
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

        public async Task<bool> LiftBan(string username)
            {
            var userId = await GetUserId(username);
            if (userId != null)
                {
                var user = await repository.GetByIdAsync<IdentityUser>(userId);
                user.LockoutEnabled = false;
                return true;
                }
            else return false;
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
