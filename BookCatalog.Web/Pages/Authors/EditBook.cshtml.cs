using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Data;
using BookCatalog.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCatalog.Web.Pages.Authors
{
    public class EditBookModel : PageModel
    {
        private readonly IBookCatalog catalog;

        [BindProperty(SupportsGet = true)]
        public Book Book { get; set; }

        public EditBookModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public IActionResult OnGet(int bookId)
        {
            Book = catalog.GetBookById(bookId);
            return Page();
        }
        public IActionResult OnPost()
        {
            catalog.EditBook(Book);
            catalog.Commit();
           return RedirectToPage("./Detail", new { authorId = Book.AuthorId });
        }
    }
}