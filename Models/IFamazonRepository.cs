using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    public interface IFamazonRepository
    {
        IQueryable<BookData> Books { get; }
    }
}
