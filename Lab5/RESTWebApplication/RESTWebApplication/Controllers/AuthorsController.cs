using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthorDB;
using System.Web.Script.Serialization;
using Models;

namespace RESTWebApplication.Controllers
{
    public class AuthorsController : ApiController
    {
        AuthorRepository authorRepository = new AuthorRepository();

        // GET: api/Authors
        public IEnumerable<string> Get()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return authorRepository.GetAll().Select(x => serializer.Serialize(x));
        }

        // GET: api/Authors/5
        public string Get(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(authorRepository.Get(id));
        }

        // POST: api/Authors
        public int Post([FromBody]Author author)
        {
            return authorRepository.Add(author);
        }

        // PUT: api/Authors/5
        public Author Put(int id, [FromBody]Author author)
        {
            if (id == author.Id)
                return authorRepository.Update(author);
            else
                return null;

        }

        // DELETE: api/Authors/5
        public bool Delete(int id)
        {
            return authorRepository.Delete(id);
        }
    }
}
