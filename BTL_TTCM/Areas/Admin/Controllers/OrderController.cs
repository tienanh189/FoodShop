using Microsoft.AspNetCore.Mvc;
using BTL_TTCM.Models;
using BTL_TTCM.Data;
using System.Collections.Generic;
using System.Linq;

namespace BTL_TTCM.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {
        private readonly VegetableDbContext db;

        public OrderController(VegetableDbContext db1)
        {
            db= db1;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> obj = db.orders;
            return View(obj);
        }

        public IActionResult Detail(int id)
        {
            var orders = from o in db.ordersDetail
                         where o.OrderId == id
                         select o;
            return View(orders);
        }
    }
}
