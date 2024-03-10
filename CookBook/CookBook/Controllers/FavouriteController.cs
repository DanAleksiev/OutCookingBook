using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
    {
    public class FavouriteController : Controller
        {
        public IActionResult Index()
            {
            return View();
            }
        }
    }
