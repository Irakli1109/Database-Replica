using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Book
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }

        public Book(string author, string isbn, double price, string title)
        {
            Author = author;
            ISBN = isbn;
            Price = price;
            Title = title;
        }

        public Book()
        {

        }
    }
}
