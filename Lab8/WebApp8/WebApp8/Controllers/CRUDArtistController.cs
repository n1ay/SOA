using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp8.CRUD;
using WebApp8.Models;

namespace WebApp8.Controllers
{
    public class CRUDArtistController : ApiController
    {
        ArtistRepository repository = new ArtistRepository(ArtistRepository.PostgreSQL);

        // GET: api/CRUDArtist
        public IEnumerable<Artist> Get()
        {
            return repository.GetAll().AsEnumerable();
        }

        // GET: api/CRUDArtist/5
        public Artist Get(int id)
        {
            return repository.Get(id);
        }

        // POST: api/CRUDArtist
        public Artist Post([FromBody]Artist artist)
        {
            return repository.Update(artist);
        }

        // PUT: api/CRUDArtist/5
        public int Put(int id, [FromBody]Artist artist)
        {
            if (id == artist.Id)
                return repository.Add(artist);
            else
                return -1;
        }

        // DELETE: api/CRUDArtist/5
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
