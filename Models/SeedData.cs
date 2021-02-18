using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Models
{
    //this is where we will have the seed data for the database
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            FamazonDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<FamazonDbContext>();

            //if migrations need to be run, it will run them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if there already isnt seeded data, then it will seed the data
            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    //add the data to the database
                    new BookData
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95
                    }

                    );

                context.SaveChanges();
            }
        }
    }
}
