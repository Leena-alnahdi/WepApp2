using Microsoft.AspNetCore.Mvc;

namespace WepApp2.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
