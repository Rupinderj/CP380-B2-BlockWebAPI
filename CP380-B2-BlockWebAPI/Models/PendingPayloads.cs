using CP380_B1_BlockList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Models
{
    public class PendingPayloads
    {
        // TODO
         
    
        public List<Payload> Payloads { get; set; }

        public PendingPayloads(List<Payload> Payloads)
        {
            this.Payloads = Payloads;
        }

       
    }
    
}
