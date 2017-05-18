using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp8.CRUD;
using WebApp8.Models;
using WebApp8.Services;

namespace WebApp8.Controllers
{
    public class CRUDArtistController : ApiController
    {
        IArtistsRepository _artistRepository;
        ILogger _logger;

        CRUDArtistController(IArtistsRepository artistRepository, ILogger logger)
        {
            _artistRepository = artistRepository;
            _logger = logger;
        }

        // GET: api/CRUDArtist
        public IEnumerable<Artist> Get()
        {
            _logger.Write("Get all Artists", LogLevel.INFO);
            return _artistRepository.GetAll().AsEnumerable();
        }

        // GET: api/CRUDArtist/5
        public Artist Get(int id)
        {
            _logger.Write("Get artist id "+id, LogLevel.INFO);
            return _artistRepository.Get(id);
        }

        // POST: api/CRUDArtist
        public Artist Post([FromBody]Artist artist)
        {
            _logger.Write("Post artist", LogLevel.INFO);
            return _artistRepository.Update(artist);
        }

        // PUT: api/CRUDArtist/5
        public int Put(int id, [FromBody]Artist artist)
        {
            _logger.Write("Put artist id "+id, LogLevel.INFO);
            if (id == artist.Id)
                return _artistRepository.Add(artist);
            else
                return -1;
        }

        // DELETE: api/CRUDArtist/5
        public bool Delete(int id)
        {
            _logger.Write("Delete artist id "+id, LogLevel.INFO);
            return _artistRepository.Delete(id);
        }
    }
}
