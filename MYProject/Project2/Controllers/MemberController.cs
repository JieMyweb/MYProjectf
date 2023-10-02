using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;

namespace Project2.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly ShopContext _db;

        public MemberController(ShopContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Home");
        }
        public IActionResult ShoppingCar()
        {
            string fUserId = User.Identity.Name;
            var orderDetails = _db.tOrderDetail.Where
                (m => m.fUserId == fUserId && m.fIsApproved == "購物車")
                .ToList();
            return View(orderDetails);
        }
        [HttpPost]
        public IActionResult ShoppingCar(string fReceiver, string fEmail, string fAddress)
        {
            string fUserId = User.Identity.Name;
            string guid = Guid.NewGuid().ToString();
            tOrder order = new tOrder();
            order.fOrderGuid = guid;
            order.fUserId = fUserId;
            order.fReceiver = fReceiver;
            order.fEmail = fEmail;
            order.fAddress = fAddress;
            order.fDate = DateTime.Now;
            _db.tOrder.Add(order);
            var carList = _db.tOrderDetail
                .Where(m => m.fIsApproved == "購物車" && m.fUserId == fUserId)
                .ToList();
            foreach (var item in carList)
            {
                item.fOrderGuid = guid;
                item.fIsApproved = "訂單";
            }
            _db.SaveChanges();
            return RedirectToAction("OrderList");
        }
        public IActionResult OrderList()
        {
            string fUserId = User.Identity.Name;
            var orders = _db.tOrder.Where(m => m.fUserId == fUserId)
                .OrderByDescending(m => m.fDate).ToList();
            return View(orders);
        }
        public IActionResult OrderListDelete(string fOrderGuid)
        {
            string UserId = User.Identity.Name;
            var Od = _db.tOrder.FirstOrDefault(m => m.fOrderGuid == fOrderGuid && m.fUserId == UserId);
            _db.tOrder.Remove(Od);
            _db.SaveChanges();
            return RedirectToAction("OrderList");
        }
        public IActionResult OrderDetail(string fOrderGuid)
        {
            var orderDetails = _db.tOrderDetail
                .Where(m => m.fOrderGuid == fOrderGuid).ToList();
            return View(orderDetails);
        }
        public IActionResult AddCar(string fPId)
        {
            string ac = User.Identity.Name;
            var od = _db.tOrderDetail.FirstOrDefault(m => m.fUserId == ac && m.fPId == fPId && m.fIsApproved == "購物車");
            if (od == null)
            {
                var pr = _db.tProduct.FirstOrDefault(m => m.fPId == fPId);
                tOrderDetail to = new tOrderDetail();
                to.fUserId = ac;
                to.fPId = fPId;
                to.fName = pr.fName;
                to.fPrice = pr.fPrice;
                to.fQty += 1;
                to.fIsApproved = "購物車";
                _db.tOrderDetail.Add(to);
            }
            else
            {
                od.fQty += 1;
            }
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Delete(string fPId) 
        {
            string fUserId = User.Identity.Name;
            var db = _db.tOrderDetail.FirstOrDefault(m=>m.fPId == fPId && m.fUserId == fUserId & m.fIsApproved == "購物車");
            if (db==null)
            {
                return Content("刪除錯誤請重新嘗試");
            }
            else
            {
                _db.tOrderDetail.Remove(db);
                _db.SaveChanges();
            }
            return RedirectToAction("ShoppingCar");
        }
    }
}
