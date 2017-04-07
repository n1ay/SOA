using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using LiteDB;

namespace AuthorDB
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly string DBPath = @"C:\Users\Kamil\Desktop\Projekty\C#\SOA\Lab5\RESTWebApplication\authors";

        public int Add(Author author)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                if (repository.FindById(author.Id) == null)
                    repository.Insert(InverseMap(author));
                else
                    repository.Update(InverseMap(author));
                return author.Id;
            }
        }

        public bool Delete(int id)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                return repository.Delete(id);
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                return Map(repository.FindById(id));
            }
        }

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var collection = repository.FindAll();
                return collection.Select(x => Map(x)).ToList();
                
            }
        }

        public Author Update(Author author)
        {
            using(var db = new LiteDatabase(DBPath))
            {
                var dbObj = InverseMap(author);
                var repository = db.GetCollection<AuthorDB>("authors");
                if (repository.Update(dbObj))
                    return author;
                else
                    return null;
            }
        }

        Author Map(AuthorDB authordb)
        {
            if (authordb == null)
                return null;
            Author result = new Author();
            result.AuthorName = authordb.AuthorName;
            result.AuthorSurname = authordb.AuthorSurname;
            result.Id = authordb.Id;
            return result;
        }

        AuthorDB InverseMap(Author author)
        {
            if (author == null)
                return null;
            AuthorDB result = new AuthorDB();
            result.Id = author.Id;
            result.AuthorName = author.AuthorName;
            result.AuthorSurname = author.AuthorSurname;
            return result;
        }
    }
}
