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
                        Price = 9.95,
                        PageNum = 1488
                    },

                    new BookData
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleInit = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        PageNum = 944
                    },

                    new BookData
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        PageNum = 832
                    },

                    new BookData
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleInit = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        PageNum = 864
                    },

                    new BookData
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        PageNum = 528
                    },

                    new BookData
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Micheal",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        PageNum = 288
                    },

                    new BookData
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        PageNum = 304
                    },

                    new BookData
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Micheal",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        PageNum = 240
                    },

                    new BookData
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16,
                        PageNum = 400
                    },

                    new BookData
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03,
                        PageNum = 642
                    },

                    new BookData
                    {
                        Title = "It",
                        AuthorFirstName = "Stephen",
                        AuthorLastName = "King",
                        Publisher = "Viking Press",
                        ISBN = "978-1501142970",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 11.75,
                        PageNum = 1138
                    },

                    new BookData
                    {
                        Title = "Lost on a Mountain in Maine",
                        AuthorFirstName = "Don",
                        AuthorLastName = "Fendler",
                        Publisher = "Harper Collins",
                        ISBN = "978-0688115739",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 9.99,
                        PageNum = 117
                    },

                    new BookData
                    {
                        Title = "Telling Lies",
                        AuthorFirstName = "Paul",
                        AuthorLastName = "Ekman",
                        Publisher = "Harper Collins",
                        ISBN = "978-0393337457",
                        Classification = "Non-Fiction",
                        Category = "Self Help",
                        Price = 16.47,
                        PageNum = 416
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
