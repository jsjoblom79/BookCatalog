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
    public class AddModel : PageModel
    {
        private readonly IBookCatalog catalog;
        [BindProperty]
        public Author Author { get; set; }

        public AddModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public IActionResult OnGet(int? authorId)
        {
            if(authorId.HasValue)
            {
                Author = catalog.GetAuthorById(authorId.Value);
            }
            else
            {
                Author = new Author();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            catalog.AddAuthor(Author);
            catalog.Commit();
            return RedirectToPage("./Detail",new { authorId = Author.Id});
        }
    }
}