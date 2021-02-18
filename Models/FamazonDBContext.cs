using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    //allows from CRUD Operations for the database
    //inherits from a class imported by the installed packages
    public class FamazonDbContext : DbContext
    {
        public FamazonDbContext(DbContextOptions<FamazonDbContext> options) : base(options)
        {

        }

        //creates a DbSet of a type BookData, which is the model that we generated
        public DbSet<BookData> Books { get; set; }

    }
}
