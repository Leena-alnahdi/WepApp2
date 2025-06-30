using Microsoft.AspNetCore.Mvc;

namespace WebsiteProject.Controllers
{
    public class SupervisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Profile()
        {
            return View();
        }
    }
}
