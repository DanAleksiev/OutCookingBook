using CookBook.Areas.Admin.Enum;

namespace CookBook.Areas.Admin.Models
    {
    public class ChangeUserRoleForm
        {
        public string Username { get; set; } = string.Empty;
        public RolesEnum Roles { get; init; }
    }
    }
