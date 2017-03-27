using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class BlackHole : IBlackHole
    {
        public Starship PullStarship(Starship ship)
        {
            if(ship.Captain.Age <= 40)
            {
                foreach(Person person in ship.Crew)
                {
                    person.Age += 20;
                }
            }
            return ship;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
