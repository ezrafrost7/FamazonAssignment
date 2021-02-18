using FamazonAssignment.Models;
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

        public HomeController(ILogger<HomeController> logger, IFamazonRepository repository)
        {
            _logger = logger;
            //sets the private variable/object _repository
            _repository = repository;
        }

        public IActionResult Index()
        {
            //inputting the repository is passing it to the view for use in the view, like displaying the data
            return View(_repository.Books);
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
