using Microsoft.AspNetCore.Mvc;
using BTL_TTCM.Data;
using BTL_TTCM.Models;
using System.Collections.Generic;
using System;

namespace BTL_TTCM.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly VegetableDbContext db;

        public AccountController(VegetableDbContext db1)
        {
            db = db1;
        }
        public IActionResult Index()
        {
            IEnumerable<User> obj = db.users;
            return View(obj);
        }


        // GET: ProductController/Edit/5
        public IActionResult Edit(string username)
        {
            User user = db.users.Find(username);
            return View(user);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            try
            {
                User u= db.users.Find(user.UserName);
                u.Role = user.Role;
                u.FullName = user.FullName;
                u.Email = user.Email;
                u.PhoneNumber =user.PhoneNumber;
                db.users.Update(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }           
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return View(user);
        }


    }
}
