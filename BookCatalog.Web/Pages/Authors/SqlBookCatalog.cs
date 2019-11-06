using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCatalog.Domain;

namespace BookCatalog.Data
{
    public class SqlBookCatalog : IBookCatalog
    {
        private readonly BookDbContext db;

        public SqlBookCatalog(BookDbContext db)
        {
            this.db = db;
        }
        public Author AddAuthor(Author author)
        {
            db.Add(author);
            return author;
        }

        public Book AddBook(Book book)
        {
            db.Add(book);
            return book;
        }

        public int BooksByAuthor(int authorId)
        {
            var books = from book in db.Books
                   where book.AuthorId == authorId
                   select book;
            return books.Count();
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Author DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Book DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Author EditAuthor(Author author)
        {
            db.Update(author);
            return author;
        }

        public Book EditBook(Book book)
        {
            db.Update(book);
            return book;

        }

        public Author GetAuthorById(int id)
        {
            return db.Authors.Find(id);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return from auth in db.Authors
                   select auth;
        }

        public Book GetBookById(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return from book in db.Books
                   select book;
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return from book in db.Books
                   where book.AuthorId == authorId
                   select book;
        }

        public void UpdateBooks(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
