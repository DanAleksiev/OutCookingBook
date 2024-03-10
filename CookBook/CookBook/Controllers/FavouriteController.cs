using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
    {
    public class FavouriteController : BaseController
        {
        public async Task<IActionResult> Drinks()
            {
            return View();
            }
        }
    }
