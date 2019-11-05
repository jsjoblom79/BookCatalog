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
    public class AddBooksModel : PageModel
    {
        private readonly IBookCatalog catalog;
        
        public Author Author { get; set; }
        [BindProperty(SupportsGet =true)]
        public Book Book { get; set; }
        public AddBooksModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public IActionResult OnGet(int authorId)
        {
            Author = catalog.GetAuthorById(authorId);
            Book = new Book();
            Book.AuthorId = authorId;
            return Page();
        }
        public IActionResult OnPost(int authorId)
        {
            Book.AuthorId = authorId;
            catalog.AddBook(Book);
            catalog.Commit();
            return RedirectToPage("./Detail", new { authorId = Book.AuthorId });
        }
    }
}