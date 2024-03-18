using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
    {
    public class HealthController : Controller
        {

        public async Task<IActionResult> AdvicePosters()
            {


            return View();
            }
        }
    }
