using Microsoft.AspNetCore.Mvc;

namespace CookBook.Areas.Admin.Controllers
    {
    public class AdminController : BaseController
        {
        public IActionResult Index()
            {
            return View();
            }
        }
    }
