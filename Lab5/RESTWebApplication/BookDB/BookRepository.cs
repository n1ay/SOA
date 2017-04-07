using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;
using LiteDB;

namespace BookDB
{
    public class BookRepository : IBookRepository
    {
        private readonly string DBPath = @"C:\Users\Kamil\Desktop\Projekty\C#\SOA\Lab5\RESTWebApplication\books";

        public int Add(Book book)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<BookDB>("books");
                if (repository.FindById(book.Id) == null)
                    repository.Insert(InverseMap(book));
                else
                    repository.Update(InverseMap(book));
                return book.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<BookDB>("books");
                return repository.Delete(id);
            }
        }

        public Book Get(int id)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<BookDB>("books");
                return Map(repository.FindById(id));
            }
        }

        public List<Book> GetAll()
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<BookDB>("books");
                var collection = repository.FindAll();
                return collection.Select(x => Map(x)).ToList();
            }
        }

        public Book Update(Book book)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<BookDB>("books");
                if (repository.Update(InverseMap(book)))
                    return book;
                else
                    return null;
            }
        }

        Book Map(BookDB bookdb)
        {
            if (bookdb == null)
                return null;
            Book result = new Book();
            result.Id = bookdb.Id;
            result.BookTitle = bookdb.BookTitle;
            result.ISBN = bookdb.ISBN;
            return result;
        }

        BookDB InverseMap(Book book)
        {
            if (book == null)
                return null;
            BookDB result = new BookDB();
            result.Id = book.Id;
            result.ISBN = book.ISBN;
            result.BookTitle = book.BookTitle;
            return result;
        }
    }
}
