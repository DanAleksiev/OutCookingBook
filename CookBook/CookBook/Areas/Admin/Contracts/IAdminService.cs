namespace CookBook.Areas.Admin.Contracts
    {
    public interface IAdminService
        {
        Task<bool> UserExist(string username);
        Task<string> GetUserId(string username);
        Task<string> GetRoleId(string role);

        Task ChangeRole(string username, string role);
        Task<bool> Ban(string username);
        Task<bool> LiftBan(string username);
        }
    }
