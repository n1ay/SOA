using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicAdventureDTO;
using SpaceWcf;
using System.ServiceModel;
using System.ServiceModel.Description;
using ImperiumWcf;

namespace ConsoleWcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri addressCosmos = new Uri("http://localhost:80/Temporary_Listen_Addresses/WCFLab3/Cosmos");
            ServiceHost selfHostCosmos = new ServiceHost(typeof(Cosmos), addressCosmos);

            Uri addressFirstOrder = new Uri("http://localhost:80/Temporary_Listen_Addresses/WCFLab3/FirstOrder");
            ServiceHost selfHostFirstOrder = new ServiceHost(typeof(FirstOrder), addressFirstOrder);

            try
            {
                selfHostCosmos.AddServiceEndpoint(typeof(ICosmos), new WSHttpBinding(), "Cosmos Endpoint");
                selfHostFirstOrder.AddServiceEndpoint(typeof(IFirstOrder), new WSHttpBinding(), "First Order Endpoint");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                selfHostCosmos.Description.Behaviors.Add(smb);
                selfHostFirstOrder.Description.Behaviors.Add(smb);

                selfHostCosmos.Open();
                Console.WriteLine("Service Cosmos is working");
                selfHostFirstOrder.Open();
                Console.WriteLine("Service First Order is working");         

                Console.ReadKey();
                selfHostCosmos.Close();
                selfHostFirstOrder.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception of type CommunicationException occured: {0}", ex.Message);
                selfHostCosmos.Abort();
                selfHostFirstOrder.Abort();
            }
        }
    }
}
