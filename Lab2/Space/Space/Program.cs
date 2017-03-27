using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
/*
* Do references należy dodać System.ServiceModel
* 
*/
namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:80/Temporary_Listen_Addresses/WCFTest");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                //obsługa endpointu
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "TestServiceEndpoint");

                //wystawienie wsdl, aby był widoczny
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("Service is working!");
                Console.ReadLine();

                selfHost.Close();
            }
            catch(CommunicationException e)
            {
                Console.WriteLine("An exception of type CommunicationException occured: {0}", e.Message);
                selfHost.Abort();
            }
        }
    }
}
