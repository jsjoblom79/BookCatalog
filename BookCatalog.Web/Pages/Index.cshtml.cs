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
        public IndexModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public void OnGet()
        {
            Authors = catalog.GetAuthors();
            Books = catalog.GetBooks();
        }
    }
}
