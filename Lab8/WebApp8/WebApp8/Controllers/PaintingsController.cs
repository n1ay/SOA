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
    public class PaintingsController : ApiController
    {
        IPaintingsRepository _paintingsRepository;
        ILogger _logger;

        public PaintingsController(IPaintingsRepository paintingsRepository, ILogger logger)
        {
            _paintingsRepository = paintingsRepository;
            _logger = logger;
        }

        public IEnumerable<Painting> Get()
        {
            _logger.Write("Get All Paintings", LogLevel.INFO);
            return _paintingsRepository.GetAll();
        }

        // GET: api/Paintings/5
        public Painting Get(int id)
        {
            _logger.Write("Get Painting no. "+id, LogLevel.INFO);
            return _paintingsRepository.Get(id);
        }

        // POST: api/Paintings
        public Painting Post([FromBody]Painting painting)
        {
            _logger.Write("Post painting", LogLevel.INFO);
            return _paintingsRepository.Update(painting);
        }

        // PUT: api/Paintings/5
        public int Put(int id, [FromBody]Painting painting)
        {
            _logger.Write("Put painting id "+id, LogLevel.INFO);
            if (id == painting.Id)
                return _paintingsRepository.Add(painting);
            return -1;
        }

        // DELETE: api/Paintings/5
        public bool Delete(int id)
        {
            _logger.Write("Delete painting id "+id, LogLevel.INFO);
            return _paintingsRepository.Delete(id);
        }
    }
}
