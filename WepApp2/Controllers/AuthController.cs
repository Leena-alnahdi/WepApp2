using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
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
        public async Task<IActionResult> Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName && u.UserPassWord == user.UserPassWord);

            if (existingUser != null)
            {
                // إنشاء قائمة الـ Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existingUser.UserName),
                    new Claim(ClaimTypes.Role, existingUser.UserRole ?? "Student")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // تسجيل الدخول بالكوكيز
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // التوجيه حسب الدور
                if (existingUser.UserRole == "Supervisor")
                    return RedirectToAction("Index", "Supervisor");

                return RedirectToAction("HomePage", "Auth");
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
            if (user.UserPassWord != ConfirmPassword)
            {
                ViewBag.PasswordMismatch = true;
                return View(user);
            }

            if (string.IsNullOrWhiteSpace(user.UserPassWord))
            {
                ViewBag.PasswordEmpty = true;
                return View(user);
            }

            var existingUser = _context.Users
                .FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);

            if (existingUser != null)
            {
                ViewBag.UserExists = true;
                return View(user);
            }

            if (ModelState.IsValid)
            {
                user.LastLogIn = DateTime.Now;
                user.IsActive = true;

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(user);
        }

        // Dashboard view
        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }

        // GET: Forgot Password
        [HttpGet]
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
                    // إرسال البريد يتم هنا (إن وجد)
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

        // ✅ تسجيل الخروج
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
