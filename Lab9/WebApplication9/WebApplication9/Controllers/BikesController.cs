using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using ClassLibrary;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.OData.Routing;

namespace WebApplication9.Controllers
{
    public class BikesController : ODataController
    {
        VehiclesContext db = new VehiclesContext();

        [EnableQuery]
        public IQueryable<Bike> Get()
        {
            return db.Bikes;
        }
        [EnableQuery]
        public SingleResult<Bike> Get([FromODataUri] int key)
        {
            IQueryable<Bike> result = db.Bikes.Where(p => p.BikeID == key);
            return SingleResult.Create(result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery]
        public async Task<IHttpActionResult> Post(Bike bike)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Bikes.Add(bike);
            await db.SaveChangesAsync();
            return Created(bike);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery]
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Bike update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.BikeID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery]
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await db.Bikes.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Bikes.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool BikeExists(int key)
        {
            return db.Bikes.Any(p => p.BikeID == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
