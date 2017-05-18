using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class BooksInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<BooksContext>
    {
        protected override void Seed(BooksContext context)
        {
            var authors = new List<Author>()
            {
                new Author() { Id=1, AuthorName="Donald", AuthorSurname="Trump" },
                new Author() { Id=2, AuthorName="Rocky", AuthorSurname="Balboa" }
            };
            authors.ForEach(x => context.Authors.Add(x));
            context.SaveChanges();

            var books = new List<Book>()
            {
                new Book() { Id=1, BookTitle="Make America Great Again", ISBN="1337" },
                new Book() { Id=2, BookTitle="How to C#", ISBN="123123" }
            };
            books.ForEach(x => context.Books.Add(x));
            context.SaveChanges();
        }
    }
}