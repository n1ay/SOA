using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookDB;
using AuthorDB;
using Models;
using System.Web.Script.Serialization;

namespace RESTWebApplication.Controllers
{
    public class BooksController : ApiController
    {
        BookRepository bookRepository = new BookRepository();

        // GET: api/Books
        public IEnumerable<string> Get()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return bookRepository.GetAll().Select(x => serializer.Serialize(x));
        }

        // GET: api/Books/5
        public string Get(int id)
        {
            Book book = bookRepository.Get(id);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(book);
        }

        // GET: api/Books?search=title
        public IEnumerable<string> Get([FromUri]string search)
        {
            List<Book> allBooks = bookRepository.GetAll().Where(x => x.BookTitle.Contains(search)).ToList();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return allBooks.Select(x => serializer.Serialize(x));
        }

        // POST: api/Books
        public int Post([FromBody]Book book)
        {
            return bookRepository.Add(book);
        }

        // PUT: api/Books/5
        public Book Put(int id, [FromBody]Book book)
        {
            if(id == book.Id)
            {
                return bookRepository.Update(book);
            }
            return null;
        }

        // DELETE: api/Books/5
        public bool Delete(int id)
        {
            return bookRepository.Delete(id);
        }
    }
}
