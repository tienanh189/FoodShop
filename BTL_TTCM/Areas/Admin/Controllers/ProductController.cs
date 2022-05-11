using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_TTCM.Data;
using BTL_TTCM.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BTL_TTCM.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly VegetableDbContext db;
        public ProductController(VegetableDbContext db1)
        {
            db = db1;
        }
        // GET: ProductController
        public IActionResult Index()
        {
            IEnumerable<Product> obj = db.products;
            return View(obj);
        }       

        // GET: ProductController/Create
        public IActionResult Create()
        {
            Product product = new Product();
            ViewBag.CatId = new SelectList(db.categories, "CatId", "CatName");
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {                  
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
            catch(Exception e)
            {
                
            }
            ViewBag.CatId = new SelectList(db.categories, "CatId", "CatName");
            return View();
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            Product product = db.products.Find(id);
            ViewBag.CatId = new SelectList(db.categories, "CatId", "CatName");
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Product product)
        {
            try
            {
                Product p = db.products.Find(id);
                p.ProductName = product.ProductName;
                p.Descriptions = product.Descriptions;
                p.CatId = product.CatId;
                p.oriprice = product.oriprice;
                p.Supplier = product.Supplier;
                p.ProductName = product.ProductName;
                p.Image = product.Image;
                db.products.Update(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
               
            }         
            ViewBag.CatId = new SelectList(db.categories, "CatId", "CatName");
            return View();
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            Product product = db.products.Find(id);
            return View(product);
        }

        
        public IActionResult DeleteConfirm(int id)
        {
            try
            {        
                 Product product = db.products.Find(id);
                db.products.Remove(product);
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
