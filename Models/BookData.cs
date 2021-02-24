using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    public class BookData
    {
        //primary key for the book
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleInit { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        //this needs to have its own verification type
        [Required]
        [RegularExpression(@"^\d{2,3}[-]{0,1}\d{10}|\d{9,11}$", ErrorMessage = "Not entered in valid ISBN format")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int PageNum { get; set; }
    }
}
