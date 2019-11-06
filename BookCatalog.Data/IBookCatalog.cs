using BookCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Data
{
    public interface IBookCatalog
    {
        IEnumerable<Author> GetAuthors();
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        IEnumerable<Book> GetBooks();
        Author GetAuthorById(int id);
        Author AddAuthor(Author author);
        Author EditAuthor(Author author);
        Author DeleteAuthor(int id);
        Book GetBookById(int id);
        Book AddBook(Book book);
        Book EditBook(Book book);
        Book DeleteBook(int id);
        int Commit();
        int BooksByAuthor(int authorId);
        void UpdateBooks(Book book);
    }
}
