using Microsoft.AspNetCore.Mvc;
using BTL_TTCM.Data;
using BTL_TTCM.Models;
using System.Collections.Generic;

namespace BTL_TTCM.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactUsController : Controller
    {
        private readonly VegetableDbContext db;

        public ContactUsController(VegetableDbContext db1)
        {
            db = db1;
        }
        public IActionResult Index()
        {
            IEnumerable<Contact> obj = db.contacts;
            return View(obj);
        }

    
    }
}
