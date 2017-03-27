using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmicAdventureDTO;
using SpaceWcf;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConsoleWcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:80/Temporary_Listen_Addresses/WCFLab2");
            ServiceHost selfHost = new ServiceHost(typeof(Cosmos), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ICosmos), new WSHttpBinding(), "Test Service Endpoint");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("Service is working");

                Console.ReadKey();
                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception of type CommunicationException occured: {0}", ex.Message);
                selfHost.Abort();
            }
        }
    }
}
