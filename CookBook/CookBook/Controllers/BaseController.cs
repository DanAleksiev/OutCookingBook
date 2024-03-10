using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
    {
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BaseController : Controller
        {

        }
    }
