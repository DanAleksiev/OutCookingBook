using CookBook.Areas.Admin.Models;

namespace CookBook.Areas.Admin.Contracts
    {
    public interface IAdminService
        {
        Task<bool> UserExist(string username);
        Task<string> GetUserId(string username);
        Task<string> GetRoleId(string role);

        Task ChangeRole(string username, string role);
        Task<string> Ban(BanFormModel model);
        Task<string> LiftBan(LiftBanModel model);
        }
    }
