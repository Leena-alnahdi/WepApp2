
using Microsoft.AspNetCore.Mvc;

namespace KauAuthPortal.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
