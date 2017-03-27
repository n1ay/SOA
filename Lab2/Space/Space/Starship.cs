using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class Starship
    {
        public string Name
        {
            get; set;
        }
        public Person Captain
        {
            get; set;
        }
        public List<Person> Crew
        {
            get; set;
        }
    }
}
