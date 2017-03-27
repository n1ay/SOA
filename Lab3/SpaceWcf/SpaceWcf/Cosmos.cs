using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CosmicAdventureDTO;

namespace SpaceWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class Cosmos: ICosmos
    {
        private List<SpaceSystem> _systems;

        public Spaceship GetSpaceship(int money)
        {
            List<Person> crew = new List<Person>(4);
            for(int i=0; i<4; i++)
                crew.Add(new Person("Name", "Nick", 20));

            int power = 0;
            Random random = new Random();
            if (money > 1000 && money <= 3000)
                power = random.Next(10, 25);
            else if (money > 3000 && money <= 10000)
                power = random.Next(20, 35);
            else if (money > 10000)
                power = random.Next(35, 60);

            return new Spaceship(crew, 0, power);
        }

        public SpaceSystem GetSystem()
        {
            try
            {
                return _systems.First();
            } catch (ArgumentNullException)
            {
                return null;
            }
        }

        public void InitializeGame()
        {
            Random random = new Random();
            _systems = new List<SpaceSystem>();
            for(int i=0; i<4; i++)
                _systems.Add(new SpaceSystem("System" + random.Next(1, 100), random.Next(10, 40), random.Next(20, 120), random.Next(3000, 7000)));
        }

        public Spaceship SendStarship(Spaceship spaceship, string systemName)
        {
            bool exists = false;
            SpaceSystem system = null;
            foreach(SpaceSystem sys in _systems)
            {
                if(sys.Name == systemName)
                {
                    exists = true;
                    system = sys;
                    break;
                }
            }
            if (exists)
            {
                if (spaceship.ShipPower <= 20)
                {
                    foreach (Person person in spaceship.Crew)
                    {
                        person.Age += system.BaseDistance * 6;
                    }
                }
                else if (spaceship.ShipPower > 20 && spaceship.ShipPower <= 30)
                {
                    foreach (Person person in spaceship.Crew)
                    {
                        person.Age += system.BaseDistance * 3;
                    }
                }
                else
                {
                    foreach (Person person in spaceship.Crew)
                    {
                        person.Age += system.BaseDistance * 2;
                    }
                }

                for(int i=0; i<spaceship.Crew.Count;)
                {
                    if (spaceship.Crew.ElementAt(i).Age > 90)
                    {
                        spaceship.Crew.RemoveAt(i);
                    }
                    else
                        i++;
                }

                if (spaceship.ShipPower >= system.MinShipPower)
                {
                    spaceship.Gold = system.Gold;
                    _systems.Remove(system);
                }

                return spaceship;
            }
            spaceship.Crew.Clear();
            return spaceship;
        }
    }
}
