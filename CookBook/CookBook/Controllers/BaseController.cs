using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Controllers
    {
    [Authorize]
    public class BaseController : Controller
        {
        }
    }
