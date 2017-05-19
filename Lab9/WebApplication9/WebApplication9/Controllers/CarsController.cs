using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace WebApplication9.Controllers
{
    public class CarsController : ODataController
    {
        VehiclesContext db = new VehiclesContext();

        [HttpGet]
        [ODataRoute("Dalajlama(Postal={postalCode})")]
        public IHttpActionResult GetSalesTaxRate([FromODataUri] int postalCode)
        {
            double rate = 5.6;  // Use a fake number for the sample.
            return Ok(rate);
        }

        [EnableQuery]
        public IQueryable<Car> Get()
        {
            return db.Cars;
        }

        [EnableQuery]
        public SingleResult<Car> Get([FromODataUri] int key)
        {
            IQueryable<Car> result = db.Cars.Where(p => p.ID == key);
            return SingleResult.Create(result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery]
        public async Task<IHttpActionResult> Post([FromBody]Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Cars.Add(car);
            await db.SaveChangesAsync();
            return Created(car);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery]
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Car update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ID)
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
                if (!CarExists(key))
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
            var product = await db.Cars.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            db.Cars.Remove(product);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }


        private bool CarExists(int key)
        {
            return db.Cars.Any(p => p.ID == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
