using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    public class Spaceship
    {
        [DataMember]
        public List<Person> Crew { get; set; }

        [DataMember]
        public int Gold { get; set; }

        [DataMember]
        public int ShipPower { get; set; }

        public Spaceship() { }

        public Spaceship(List<Person> crew, int gold, int shipPower)
        {
            this.Crew = crew;
            this.Gold = gold;
            this.ShipPower = shipPower;
        }
    }
}
