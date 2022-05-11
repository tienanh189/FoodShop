using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BTL_TTCM.Data;
using BTL_TTCM.Models;
using Microsoft.AspNetCore.Http;

namespace BTL_TTCM.Controllers
{
    public class UserController : Controller
    {
        private VegetableDbContext _db;

        public UserController(VegetableDbContext db1)
        {
            _db=db1;
        }
        //Get
        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            IEnumerable<User> user = _db.users;
            foreach (var item in user)
            {
                if (username==item.UserName&&password==item.Password)
                {
                    HttpContext.Session.SetString("UserName", username);
                    HttpContext.Session.SetString("FullName", item.FullName);
                    HttpContext.Session.SetString("Phone", item.PhoneNumber);
                    HttpContext.Session.SetString("Email", item.Email);
                    return Redirect("/Home/Index");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult SignUp(string report, string cf)
        {
            ViewBag.Report = report;
            ViewBag.cf = cf;
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string confirmpassword, User user)
        {
            IEnumerable<User> user1 = _db.users;
            foreach (var item in user1)
            {
                if (user.UserName == item.UserName)
                {                  
                    return RedirectToAction("SignUp",new {report = "UserName already exist"});
                }
            }
            if(confirmpassword != user.Password)
            {
                return RedirectToAction("SignUp", new { report = "",cf= "confirmpassword must like password"});
            }
            user.Role = false;
            _db.users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
