using BTL_TTCM.Data;
using BTL_TTCM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BTL_TTCM.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        private VegetableDbContext _db;

        public UserController(VegetableDbContext db1)
        {
            _db = db1;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            IEnumerable<User> user = _db.users;
            foreach (var item in user)
            {
                if (username == item.UserName && password == item.Password && item.Role==true)
                {
                    HttpContext.Session.SetString("Admin", username);                
                    return Redirect("/admin/Home/Index");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
