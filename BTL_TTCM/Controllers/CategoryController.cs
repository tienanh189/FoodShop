using BTL_TTCM.Data;
using BTL_TTCM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTL_TTCM.Controllers
{
    public class CategoryController : Controller
    {
        private readonly VegetableDbContext db;

        public CategoryController(VegetableDbContext db1)
        {
            db = db1;
        }

        
        public IActionResult RenderCat(int? id)
        {
            IEnumerable<Category> obj = db.categories;
            ViewBag.id=id;
            return View(obj);
        }

       
        public IActionResult RenderPro()
        {
            IEnumerable<Product> obj = db.products;
            return PartialView(obj);
        }

        public IActionResult ProductDetail(int? id)
        {
            Product product = db.products.Find(id);
            return View(product);
        }

        public IActionResult ChangeList(int CatID)
		{
            return RedirectToAction("RenderCat", new { id = CatID });
		}



         

        

    }
}
