using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;

namespace MobileStore.Controllers
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
    }
}
