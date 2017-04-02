using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::ObjectManagerModels;
using ObjectManagerReview.Interfaces;
using LiteDB;
using ObjectManagerReview.DBLite.Model;

namespace ObjectManagerReview.DBLite
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string DBPath = Config.PersonDBPath;

        public int Add(Person person)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var dbObject = InverseMap(person);
                var repository = db.GetCollection<PersonDB>("persons");
                if (repository.FindById(person.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<PersonDB>("persons");
                return repository.Delete(id);
            }
        }

        public Person Get(int id)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<PersonDB>("persons");
                return Map(repository.FindById(id));
            }
        }

        public List<Person> GetAll()
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var repository = db.GetCollection<PersonDB>("persons");
                var collection = repository.FindAll();
                List<Person> result = new List<Person>();
                foreach (PersonDB rdb in collection)
                    result.Add(Map(rdb));
                return result;
            }
        }

        public Person Update(Person person)
        {
            using (var db = new LiteDatabase(DBPath))
            {
                var dbObj = InverseMap(person);
                var repository = db.GetCollection<PersonDB>("persons");
                if (repository.Update(dbObj))
                    return person;
                else
                    return null;
            }
        }

        internal Person Map(PersonDB person)
        {
            if (person == null)
                return null;

            Person result = new Person();
            result.Id = person.Id;
            result.Name = person.Name;
            result.Surname = person.Surname;

            return result;
        }

        internal PersonDB InverseMap(Person person)
        {
            if (person == null)
                return null;

            PersonDB result = new PersonDB();
            result.Id = person.Id;
            result.Name = person.Name;
            result.Surname = person.Surname;

            return result;
        }
    }
}
