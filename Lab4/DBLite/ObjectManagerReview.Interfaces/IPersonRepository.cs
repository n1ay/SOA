using System.Collections.Generic;
using ObjectManager.Models;

namespace ObjectManagerReview.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        int Add(Person person);
        Person Get(int id);
        Person Update(Person person);
        bool Delete(int id);
    }
}
