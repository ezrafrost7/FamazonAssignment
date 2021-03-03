using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models.ViewModels
{
    //this class supplies and creates the information needed to create the pages dynamically
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //the number of pages is dynamically created base on the data in the DB and the other info given
        //some of the datatypes have to be forced in order to allow computation and rounding
        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}
