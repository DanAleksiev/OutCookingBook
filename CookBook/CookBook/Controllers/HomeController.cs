using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CookBook.Areas.Admin.Constants.AdminConstants;

namespace CookBook.Controllers
    {
    public class HomeController : BaseController
        {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
            {
            logger = _logger;
            }
        [AllowAnonymous]
        public IActionResult Index()
            {

            if (User.IsInRole(AdminRolleName))
                {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

            return View();
            }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
            {
            string error = "Error";
            if (statusCode == 400)
                {
                ViewBag.Error = $"{error} {statusCode}";
                ViewBag.Messege = "Couldn't find what you were looking for!";
                return View("CustomError");
                }
            else if (statusCode == 401)
                {
                ViewBag.Error = $"{error} {statusCode}";
                ViewBag.Messege = "You shoudn't be here!!";
                return View("CustomError");
                }
            else if (statusCode == 404)
                {
                ViewBag.Error = $"{error} {statusCode}";
                ViewBag.Messege = "Not Found!";
                return View("CustomError");
                }
            else if (statusCode == 500)
                {
                ViewBag.Error = $"{error} {statusCode}";
                ViewBag.Messege = "It's not you it's me!";
                return View("CustomError");
                }


            return View();
            }
        }
    }
