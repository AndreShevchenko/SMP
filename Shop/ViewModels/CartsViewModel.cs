using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class CartsViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal TotalSum => Items.Sum(x => x.TotalSum);
        public List<CartItemViewModel> Items { get; set; }
        public OrderStatus Status { get; internal set; }
    }

    public class CartItemViewModel
    {
        public decimal TotalSum => ProductPrice * Count;

        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
