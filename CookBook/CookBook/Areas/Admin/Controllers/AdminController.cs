using CookBook.Areas.Admin.Contracts;
using CookBook.Areas.Admin.Models;
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
        public async Task<IActionResult> RoleControll(ChangeUserRoleForm model)
            {
            if (!await adminService.UserExist(model.Username))
                {
                return View(model);
                }

            await adminService.ChangeRole(model.Username, model.Roles.ToString());
            return View(nameof(Index));
            }

        [HttpGet]
        public IActionResult Ban()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> Ban(BanFormModel model)
            {
            if (!await adminService.UserExist(model.Username))
                {
                ViewBag.BanStatus = "User does not exist!";
                return View(model);
                }

            var banStatus = await adminService.Ban(model);
            ViewBag.BanStatus = $"{banStatus}";

            return View(model);
            }

        [HttpGet]
        public IActionResult LiftBan()
            {
            return View();
            }

        [HttpPost]
        public async Task<IActionResult> LiftBan(LiftBanModel model)
            {
            if (!await adminService.UserExist(model.Username))
                {
                ViewBag.BanStatus = "User does not exist!";
                return View(model);
                }

            var banStatus = await adminService.LiftBan(model);
            ViewBag.BanStatus = banStatus;

            return View(model);
            }

        }
    }
