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

        public AdminService(IRepository _repository)
            {
            repository = _repository;
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
            var userId = await GetUserId(username);
            var roleId = await GetRoleId(role);

            if (userId != null && roleId != null)
                {
                await repository.AddAsync(new UserRoleModel
                    {
                    Role = roleId,
                    UserId = userId
                    });
                }
            }

        public async Task<string> GetRoleId(string role)
            {
            var roleId = await repository
                .AllReadOnly<IdentityRole>()
                .Where(r => r.Name == role)
                .FirstAsync();

            return roleId.Id;
            }

        public async Task<string> GetUserId(string username)
            {
            var user = await repository
                .All<IdentityUser>()
                .Where(u => u.UserName == username)
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
                .All<IdentityUser>()
                .AnyAsync(u => u.UserName == username);
            }
        }
    }
