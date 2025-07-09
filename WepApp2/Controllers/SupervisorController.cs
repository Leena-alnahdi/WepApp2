using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var requests = _context.Requests
                                   .Include(r => r.User)
                                   .ToList();
            return View(requests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus([FromBody] UpdateStatusRequest request)
        {
            var req = _context.Requests.FirstOrDefault(r => r.RequestId == request.RequestId);
            if (req != null)
            {
                req.SupervisorStatus = request.Status;

                // ✨ نحفظ سبب الرفض فقط لو موجود
                if (!string.IsNullOrEmpty(request.Notes))
                {
                    req.Notes = request.Notes;
                }

                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }


        public class UpdateStatusRequest
        {
            public int RequestId { get; set; }
            public string Status { get; set; }
            public string? Notes { get; set; }  // ✨ أضفنا خاصية Notes
        }

    }
}
