using Microsoft.AspNetCore.Mvc;
using WepApp2.Data;
using WepApp2.Models;

namespace WepApp2.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly AppDbContext _context;

        public SupervisorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var requests = _context.Requests.ToList(); // فقط جلب الطلبات
            return View(requests);
        }
    }
}
