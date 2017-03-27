using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    public class SpaceSystem
    {
        public int MinShipPower { get; set; }
        public int Gold { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int BaseDistance { get; set; }

        public SpaceSystem() { }

        public SpaceSystem(string name, int minShipPower, int baseDistance, int gold)
        {
            this.Name = name;
            this.MinShipPower = minShipPower;
            this.BaseDistance = baseDistance;
            this.Gold = gold;
        }
    }
}
