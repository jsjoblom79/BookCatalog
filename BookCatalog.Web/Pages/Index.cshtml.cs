using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCatalog.Data;
using BookCatalog.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCatalog.Web.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly IBookCatalog catalog;
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public int BookCount { get; set; }
        public int AuthorId { get; set; }
        public IndexModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public int GetCountByAuthor(int id)
        {
            return catalog.BooksByAuthor(id);
        }
        public void OnGet()
        {
            BookCount = catalog.BooksByAuthor(AuthorId);
            Authors = catalog.GetAuthors();
            Books = catalog.GetBooks();
        }
    }
}
