using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImperiumWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    public class FirstOrder : IFirstOrder
    {
        public int GetMoneyFromImperium()
        {
            return new Random().Next(3000, 5000);
        }
    }
}
