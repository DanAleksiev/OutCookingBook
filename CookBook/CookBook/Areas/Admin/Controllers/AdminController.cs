using CookBook.Areas.Admin.models;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Areas.Admin.Controllers
    {
    public class AdminController : BaseAdminController
        {
        public IActionResult Index()
            {
            return View();
            }

        [HttpGet]
        public async Task<IActionResult> RoleConroll()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> RoleConroll(ChangeUserRoleForm model)
            {
            //Give the role to a model here !!


            return View();
            }
        }
    }
