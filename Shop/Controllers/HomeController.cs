using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        ShopContext db;
        public HomeController(ShopContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public IActionResult Basket(int id, Product product, int count)
        {
            ViewBag.ProductId = id;
            ViewBag.Product = product;
            ViewBag.Count = count;
            var orderItem = db.OrderItems            
                .Where(p => p.Product.Id == id)
                .FirstOrDefault();

            if (orderItem == null)
            {
                db.OrderItems.Add(new OrderItem
                {
                    Product = product,
                    Count = count
                });
            }
            else
            {
                count += count;
            }

            return View(db.OrderItems.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order, OrderItem orderItem)
        {
            db.Orders.Add(order);
            db.OrderItems.Add(orderItem);
            db.SaveChanges();
            return "Спасибо за покупку!";
        }        
    }
}
