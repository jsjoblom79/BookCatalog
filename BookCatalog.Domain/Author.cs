using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Book> Books { get; set; }
        public string PenName { get; set; }
    }
}
