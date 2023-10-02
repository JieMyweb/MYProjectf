using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext _db;

        public HomeController(ShopContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var pr = _db.tProduct.OrderByDescending(m => m.fId).ToList();
            return View(pr);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(tMember db)
        {
            if (ModelState.IsValid == false) 
            { 
                return View();
            }
            var tm = _db.tMember.FirstOrDefault(m => m.fUserId == db.fUserId);
            if (tm == null)
            {
                _db.tMember.Add(db);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.msg = "帳號有人使用";
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string fUserId, string fPwd)
        {
            var user = _db.tMember.FirstOrDefault(m => m.fUserId == fUserId && m.fPwd == fPwd);

            if (user == null)
            {
                ViewBag.msg = "無此帳號密碼";
                return View();
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.fUserId),
            new Claim(ClaimTypes.Email, user.fEmail),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20) 
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Index");
        }
        public IActionResult ProductDetail(int fId)
        {
            var pr = _db.tProduct.FirstOrDefault(m => m.fId == fId);
            return View(pr);
        }
    }
}