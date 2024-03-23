using CookBook.Core.Constants;
using CookBook.Core.Contracts.Users.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
        {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
            {
            userService = _userService;
            }

        public async Task<IActionResult> All()
            {
            var model = await userService.All();

            return View(model);
            }

        [HttpPost]
        public async Task<IActionResult> Forget(string userId)
            {
            bool result = await userService.Forget(userId);

            if (result)
                {
                TempData[MessageConstant.SuccessMessage] = "User is now forgotten";
                }
            else
                {
                TempData[MessageConstant.ErrorMessage] = "User is unforgetable";
                }

            return RedirectToAction(nameof(All));
            }
        }
    }
