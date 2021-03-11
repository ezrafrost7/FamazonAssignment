using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamazonAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FamazonAssignment.Infrastructure;

namespace FamazonAssignment.Pages
{
    public class PurchaseModel : PageModel
    {
        private IFamazonRepository repository;
        public PurchaseModel (IFamazonRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            BookData book = repository.Books.FirstOrDefault(b => b.BookID == bookId);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //this is for removing an item and refeshing the page
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookID == bookId).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
