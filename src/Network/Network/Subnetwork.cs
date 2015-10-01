using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Subnetwork
    {
        public IpAddress NetworkId { get; set; }
        public IpAddress BroadcastAddress { get; set; } 
        public IpAddress FirstUsable { get; set; }
        public IpAddress LastUsable { get; set; }


    }
}
