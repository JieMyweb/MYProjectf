using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Microsoft.EntityFrameworkCore;

namespace Project2.ViewComponents
{
    public class PDViewComponents : ViewComponent
    {
        private readonly ShopContext _vc;
        public PDViewComponents(ShopContext vc)
        {
            _vc = vc;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
