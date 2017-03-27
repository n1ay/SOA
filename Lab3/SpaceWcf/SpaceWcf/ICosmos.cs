using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CosmicAdventureDTO;

namespace SpaceWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICosmos
    {
        [OperationContract]
        void InitializeGame();

        [OperationContract]
        Spaceship SendStarship(Spaceship spaceship, string systemName);

        [OperationContract]
        SpaceSystem GetSystem();

        [OperationContract]
        Spaceship GetSpaceship(int money);

    }
}
