using CookBook.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Areas.Admin.Controllers
    {
    public class AdminController : BaseController
        {
        public IActionResult Index()
            {
            return View();
            }

        [HttpGet]
        public async Task<IActionResult> GiveRoleToUser()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> GiveRoleToUser(UserRoleModel model)
            {
            //Give the role to a model here !!


            return View();
            }
        }
    }
