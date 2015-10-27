using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class FullNetwork
    {
        private List<Subnetwork> Subnets { get; set; }

        public FullNetwork()
        {
            // Maybe a queue
            Subnets = new List<Subnetwork>();
        }
    }
}
