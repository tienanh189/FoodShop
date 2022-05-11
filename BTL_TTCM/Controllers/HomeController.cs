using BTL_TTCM.Data;
using BTL_TTCM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace BTL_TTCM.Controllers
{
    public class HomeController : Controller
    {
        private readonly VegetableDbContext db;

        public HomeController(VegetableDbContext db1)
        {
            db = db1;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> obj = db.products;
            return View(obj);
        }

        public IActionResult RenderContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RenderContactUs(Contact contact)
        {
            try
            {
                db.contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }            
            return View();
        }

        public IActionResult ShopCart()
        {
            string name = HttpContext.Session.GetString("UserName").ToString();
            var cart = from p in db.carts
                        where p.Username == name
                        select p;                   
            return View(cart);
        }

       
        public IActionResult AddCart(int? id, int sl)
        {
            var pro = from p in db.products
                      where p.ProductId == id
                      select p;
            int num = sl;
            int idP = id.Value;
            Product prod=null;
            foreach(var item in pro)
            {
                prod = item;
            }
            string name = HttpContext.Session.GetString("UserName").ToString();
            if (name != null)
            {            
                var cart1 = from c in db.carts
                            where c.Name == prod.ProductName && c.Username==name
                            select c;                            
                if (cart1.Count()==0)
                {
                    Cart cart = new Cart(prod, sl, name);
                    db.carts.Add(cart);
                    db.SaveChanges();
                    return Redirect("/Home/ShopCart");
                }
                else
                {
                    Cart c = null;
                    foreach (var item in cart1)
                    {
                        c = item;
                    }
                    c.quantity+=sl;
                    db.SaveChanges();
                    return Redirect("/Home/ShopCart");
                }              
               
            }
            return Redirect("/User/Login");
        }

        public IActionResult ClearShopCart()
        {
            string name = HttpContext.Session.GetString("UserName").ToString();
            var cart = from p in db.carts
                       where p.Username == name
                       select p;
            db.carts.RemoveRange(cart);
            db.SaveChanges();
            return RedirectToAction("ShopCart");
        }

        public IActionResult DeleteCart(int? id)
        {
            Cart cart = db.carts.Find(id);
            db.carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("ShopCart");
        }

        public IActionResult Increase(int id)
        {
            Cart cart = db.carts.Find(id);
            cart.quantity ++;
            db.SaveChanges();
            return RedirectToAction("ShopCart");
        }

        public IActionResult Decrease(int id)
        {
            Cart cart = db.carts.Find(id);          
            if(cart.quantity > 0)
            {
                cart.quantity--;
            }
            db.SaveChanges();
            return RedirectToAction("ShopCart");
        }

        public IActionResult CheckOut()
        {
            string name = HttpContext.Session.GetString("UserName").ToString();           
            Order order = new Order();
            order.Username = name;
            order.dateCreate = System.DateTime.Now;
            db.orders.Add(order);
            db.SaveChanges();        
            return RedirectToAction("AddOrderDetail");
        }

        public IActionResult AddOrderDetail()
        {
            
            string name = HttpContext.Session.GetString("UserName").ToString();
            var carts = from p in db.carts
                        where p.Username == name
                        select p;
            var orders = from od in db.orders
                        where od.Username == name && od.status == false
                        select od;
            Order order1 = null;
            foreach(var i in orders)
            {
                order1 = i;
            }
            int num = order1.OrderId;         
            if (carts.Count() > 0 && orders.Count()>0)
            {
                foreach(Cart c in carts)
                {
                    OrderDetail orderDetails = new(num,c);                   
                    db.ordersDetail.Add(orderDetails);                                
                }
                order1.status = true;
                db.SaveChanges();
                return RedirectToAction("ClearShopCart");
            }
            return RedirectToAction("ShopCart");
        }

        

    }
}
