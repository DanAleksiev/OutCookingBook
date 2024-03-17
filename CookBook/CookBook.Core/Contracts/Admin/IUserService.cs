using CookBook.Core.Models.Admin;

namespace CookBook.Core.Contracts.Admin
    {
    public interface IUserService
        {
        Task<string> UserFullName(string userId);
        Task<IEnumerable<UserServiceModel>> All();
        Task<bool> Forget(string userId);
        }
    }
