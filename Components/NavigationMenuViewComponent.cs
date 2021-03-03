using FamazonAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        //create and set a new repository for the view component
        private IFamazonRepository repository;
        //set the value of the repository "manually"
        public NavigationMenuViewComponent (IFamazonRepository r)
        {
            repository = r;
        }
        //this is what is going to be used ot send the partial view to the cshtml file
        public IViewComponentResult Invoke()
        {
            //viewbag that we will be using to call the data
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //the view that we are actually returning, using queries to select the info and llambdas to dynamically set them
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
