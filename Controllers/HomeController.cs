﻿using FamazonAssignment.Models;
using FamazonAssignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //added for the database
        private IFamazonRepository _repository;

        //the page size that has been requested
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IFamazonRepository repository)
        {
            _logger = logger;
            //sets the private variable/object _repository
            _repository = repository;
        }

        //the new paging info has to be added to make the pages iterable
        //also all of the data needs to be passed, this is done by passing the booklistviewmodel
        public IActionResult Index(string category, int page = 1)
        {
            //inputting the repository is passing it to the view for use in the view, like displaying the data
            return View(new BookListViewModel
            {
                Books = _repository.Books
                //this is how you edit the view to display only the books of that category, using queries
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.Title)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                //now you add the paging info stuff
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //using a shorthand if statement to dynamically change the number of pages
                    TotalNumItems = category == null ? _repository.Books.Count() : 
                    _repository.Books.Where(x => x.Category == category).Count()
                },

                //set current category
                Category = category

            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
