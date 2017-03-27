using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    public class Person
    {
        public string Name { get; set; }
        public string Nick { get; set; }
        public float Age { get; set; }

        public Person() { }

        public Person(string name, string nick, int age)
        {
            this.Name = name;
            this.Nick = nick;
            this.Age = age;
        }
    }
}
