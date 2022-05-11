using Microsoft.AspNetCore.Mvc;
using BTL_TTCM.Models;
using BTL_TTCM.Data;
using System.Collections.Generic;
using System;

namespace BTL_TTCM.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly VegetableDbContext db;

        public CategoryController(VegetableDbContext db1)
        {
            db= db1;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> obj = db.categories;
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            try
            {
                db.categories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                throw;
            }
            return View(cat);
        }

        public IActionResult Edit(int id)
        {
            Category category = db.categories.Find(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Category cat)
        {
            try
            {
                Category category = db.categories.Find(id);
                category.CatName=cat.CatName;
                db.categories.Update(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                throw;
            }
            return View(cat);
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            Category category = db.categories.Find(id);
            return View(category);
        }


        public IActionResult DeleteConfirm(int id)
        {
            try
            {
                Category category = db.categories.Find(id);
                db.categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}
