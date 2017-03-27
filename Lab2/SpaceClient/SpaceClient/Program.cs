using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space;
using SpaceClient.BlackHoleService;

/*
 * Do references dodajemy Add service reference i wklejamy uri do naszej usługi
 * 
 */

namespace SpaceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //nazwa klasy z ServiceReferences/References.cs
            BlackHoleClient client = new BlackHoleClient();

            Console.WriteLine(client.UltimateAnswer());
            Console.ReadKey();
        }
    }
}
