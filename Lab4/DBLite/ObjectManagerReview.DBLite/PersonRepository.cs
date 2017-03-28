using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectManager.Models;
using ObjectManagerReview.Interfaces;

namespace ObjectManagerReview.DBLite
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string DBPath = Config.PersonDBPath;

        public int Add(Person person)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
