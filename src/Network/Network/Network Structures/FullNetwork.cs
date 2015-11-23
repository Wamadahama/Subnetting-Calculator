using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network.Builders;

namespace Network
{
    public class FullNetwork
    {
        //private List<Subnetwork> Subnets { get; set; }
        public Queue<Subnetwork> Subnets { get; }
        public ClassAandBBuilder ClassAorBBuilder;
        public ClassCSubnetBuilder ClassCBuilder;
         
        public FullNetwork()
        {
            Subnets = new Queue<Subnetwork>();
        }

        public static implicit operator FullNetwork(ClassAandBBuilder v)
        {
            throw new NotImplementedException();
        }
    }
}
