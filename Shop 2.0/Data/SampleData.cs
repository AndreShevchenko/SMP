using System.Linq;
using Shop.Models;

namespace Shop.Data
{
    public class SampleData
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Хлеб",
                        Price = 50
                    },
                    new Product
                    {
                        Name = "Колбаса",
                        Price = 300
                    },
                    new Product
                    {
                        Name = "Сыр",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
