using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Order
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public int QTY { get; set; }
        public double Line_Total { get; set; }

        public Order(string title, double price, int qty)
        {
            Title = title;
            Price = price;
            QTY = qty;
            Line_Total = qty * price;

        }

        public Order()
        {

        }
    }
}
