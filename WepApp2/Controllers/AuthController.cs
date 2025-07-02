using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApp2.Data;
using WepApp2.Models;

namespace WepApp2.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.PassWord == user.PassWord);

            if (existingUser != null)
            {
                // مثال: حفظ في السيشن أو الانتقال للداشبورد
                return RedirectToAction("HomePage");
            }

            ViewBag.LoginFailed = true;
            return View(user);
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string ConfirmPassword)
        {
            // التحقق من تطابق كلمتي المرور
            if (user.PassWord != ConfirmPassword)
            {
                ViewBag.PasswordMismatch = true;
                return View(user);
            }

            // التحقق من أن كلمة المرور ليست فارغة
            if (string.IsNullOrWhiteSpace(user.PassWord))
            {
                ViewBag.PasswordEmpty = true;
                return View(user);
            }

            // التحقق من وجود مستخدم بنفس اسم المستخدم أو البريد الإلكتروني
            var existingUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);

            if (existingUser != null)
            {
                ViewBag.UserExists = true;
                return View(user);
            }

            if (ModelState.IsValid)
            {
                user.UserId = new Random().Next(1000, 9999);
                user.LastLogIn = DateTime.Now;
                user.IsActive = true;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // Dashboard view
        public IActionResult HomePage()
        {
            return View();
        }

        // GET: عرض صفحة نسيت كلمة المرور
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null)
                {
                    // إرسال بريد إلكتروني فعلي هنا
                    // SendPasswordResetEmail(user.Email);

                    return RedirectToAction("Login", new { resetSuccess = true });
                }
                else
                {
                    ViewBag.Error = true;
                    return View(model);
                }
            }

            return View(model);
        }
    }
}