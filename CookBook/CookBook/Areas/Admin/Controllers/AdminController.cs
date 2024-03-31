using CookBook.Areas.Admin.Contracts;
using CookBook.Areas.Admin.models;
using CookBook.Infrastructures.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Areas.Admin.Controllers
    {
    public class AdminController : BaseAdminController
        {
        private readonly IAdminService adminService;

        public AdminController(IAdminService _adminService)
            {
            adminService = _adminService;
            }

        public IActionResult Index()
            {
            return View();
            }

        [HttpGet]
        public IActionResult RoleControll()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> RoleConroll(ChangeUserRoleForm model)
            {
            if(!await adminService.UserExist(model.Username))
                {
                return View(model);
                }

            await adminService.ChangeRole(model.Username, model.Roles.ToString());
            await Console.Out.WriteLineAsync($"{model.Username} is now {model.Roles.ToString()}");
            return View();
            }
        }
    }
