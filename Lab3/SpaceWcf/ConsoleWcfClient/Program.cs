using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWcfClient.CosmosService;
using ConsoleWcfClient.FirstOrderService;
using CosmicAdventureDTO;
using SpaceWcf;

namespace ConsoleWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CosmosClient cosmosClient = new CosmosClient();
            FirstOrderClient firstOrderClient = new FirstOrderClient();

            List<Spaceship> _spaceships = new List<Spaceship>();
            bool _anySystem = true;
            int _gold = 1000;
            int _imperiumMoneyAskCount = 4;
            cosmosClient.InitializeGame();
            while(true)
            {
                Console.WriteLine("Złoto: {0}, Pomoc od imperium: {1}", _gold, _imperiumMoneyAskCount);
                Console.WriteLine("1 - Poproś imperium o złoto\n2 - Kup statek za złoto\n3 - Wyślij statek do systemu\n4 - Zakończ grę");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    if (_imperiumMoneyAskCount > 0)
                    {
                        int gold = firstOrderClient.GetMoneyFromImperium();
                        _gold += gold;
                        _imperiumMoneyAskCount--;
                        Console.WriteLine("Otrzymano złoto: {0}.", gold);
                    }
                    else
                    {
                        Console.WriteLine("Imperium nie może ci więcej pomóc.");
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Aktualne złoto: {0}\n Za ile złota chcesz kupić statek?", _gold);
                    input = Console.ReadLine();
                    int price = int.Parse(input);
                    if (price < 0 || price > _gold)
                        Console.WriteLine("Nie masz wystarczającej ilośći złota.");
                    else
                    {
                        _spaceships.Add(cosmosClient.GetSpaceship(price));
                        _gold -= price;
                    }
                }
                else if (input == "3")
                {
                    SpaceSystem system = cosmosClient.GetSystem();
                    if (system == null)
                    {
                        Console.WriteLine("Brak systemów");
                        _anySystem = false;
                    }
                    else
                    {
                        Console.WriteLine("System: {0}, odległość: {1}.", system.Name, system.BaseDistance);
                        int spaceships = _spaceships.Count;
                        if (spaceships < 1)
                        {
                            Console.WriteLine("Brak statków");
                            continue;
                        }
                        Console.WriteLine("Statków: {0}", spaceships);
                        Console.WriteLine("Wybierz statek wpisując jego numer (albo wyjdź wpisując literę e):");
                        for (int i = 0; i < spaceships; i++)
                        {
                            Console.Write("{0}. {1}, ", i, _spaceships.ElementAt(i).ShipPower);
                            foreach (Person person in _spaceships.ElementAt(i).Crew)
                            {
                                Console.Write(person.Name + " " + person.Nick + " " + person.Age + ", ");
                            }
                            Console.WriteLine();
                        }
                        input = Console.ReadLine();
                        if (input == "e")
                            continue;
                        else
                        {
                            int idx = int.Parse(input);
                            try
                            {
                                Spaceship ship = _spaceships.ElementAt(idx);
                                _spaceships.RemoveAt(idx);
                                ship = cosmosClient.SendStarship(ship, system.Name);
                                if (ship.Gold > 0)
                                {
                                    _gold += ship.Gold;
                                    Console.WriteLine("Zdobyte złoto: {0}", ship.Gold);
                                    if (ship.Crew.Count > 0)
                                    {
                                        Console.WriteLine("Statek wrócił z załogą: {0} osob/a", ship.Crew.Count);
                                        _spaceships.Add(ship);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    if (_anySystem)
                        Console.WriteLine("Przegrana");
                    else
                        Console.WriteLine("Wygrana");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
