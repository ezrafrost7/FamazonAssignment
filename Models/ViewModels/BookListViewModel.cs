using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models.ViewModels
{
    //this is what is passed to the view instead of just the book list
    public class BookListViewModel
    {
        public IEnumerable<BookData> Books { get; set; }
        //we need to also pass the new object created to make the pages
        public PagingInfo PagingInfo { get; set; }
    }
}
