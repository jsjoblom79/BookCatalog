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
    public class DetailModel : PageModel
    {
        private readonly IBookCatalog catalog;
        [BindProperty(SupportsGet = true)]
        public Author Author { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public int NumberOfBooks { get; set; }
        public DetailModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public void OnGet(int authorId)
        {
            Author = catalog.GetAuthorById(authorId);
            Books = catalog.GetBooksByAuthor(authorId);
            NumberOfBooks = Books.Count();
        }
    }
}