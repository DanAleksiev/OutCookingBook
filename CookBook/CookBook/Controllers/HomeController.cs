using CookBook.Core.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static CookBook.Areas.Admin.Constants.AdminConstants;

namespace CookBook.Controllers
    {
    public class HomeController : Controller
        {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
            {
            logger = _logger;
            }

        public async Task<IActionResult> Index()
            {

            if (User.IsInRole(AdminRolleName))
                {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

            return View();
            }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
