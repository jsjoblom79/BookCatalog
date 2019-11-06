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
    public class EditAuthorModel : PageModel
    {
        private readonly IBookCatalog catalog;

        [BindProperty(SupportsGet =true)]
        public Author Author { get; set; }
        public EditAuthorModel(IBookCatalog catalog)
        {
            this.catalog = catalog;
        }
        public IActionResult OnGet(int authorId)
        {
            Author = catalog.GetAuthorById(authorId);
            return Page();
        }
        public IActionResult OnPost()
        {
            catalog.EditAuthor(Author);
            catalog.Commit();
            return RedirectToPage("./Detail", new { authorId = Author.Id});
        }
    }
}