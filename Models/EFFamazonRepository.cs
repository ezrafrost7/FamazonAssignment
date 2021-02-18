using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    public class EFFamazonRepository : IFamazonRepository
    {
        private FamazonDbContext _context;
        public EFFamazonRepository (FamazonDbContext context)
        {
            _context = context;
        }
        //this llambda keeps the stored Books objects up to date in the database
        public IQueryable<BookData> Books => _context.Books;
    }
}
