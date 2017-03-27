using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    [ServiceContract]
    public interface IBlackHole
    {

        [OperationContract]
        Starship PullStarship(Starship ship);

        [OperationContract]
        string UltimateAnswer();
    }
}
