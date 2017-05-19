using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClassLibrary
{
    public class VehiclesInitializer: DropCreateDatabaseIfModelChanges<VehiclesContext>
    {
        protected override void Seed(VehiclesContext context)
        {
            var cars = new List<Car>
            {
                new Car() {Name = "Furrari", Color = "Red", Type = "Fast"},
                new Car() {Name = "Nayassan", Color = "Black", Type = "Extremely Fast"}
            };
            cars.ForEach(s => context.Cars.Add(s));
            context.SaveChanges();

            var bikes = new List<Bike>
            {
                new Bike() {Name = "Voss"},
                new Bike() {Name = "Itilano"}
            };
            bikes.ForEach(a => context.Bikes.Add(a));
            context.SaveChanges();
        }

    }
}
