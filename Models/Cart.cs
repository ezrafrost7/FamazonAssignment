using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    public class Cart
    {
        //these are the properties and methods needed to substantiate the cart
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(BookData book, int quantity)
        {
            CartLine line = Lines.Where(b => b.Book.BookID == book.BookID).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //specific functionalities of the cart
        public virtual void RemoveLine(BookData book) => Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public BookData Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
