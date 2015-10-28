using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class FullNetwork
    {
        //private List<Subnetwork> Subnets { get; set; }
        public Queue<Subnetwork> Subnets { get; }
         
        public FullNetwork()
        {
            Subnets = new Queue<Subnetwork>();
        }
    }
}
