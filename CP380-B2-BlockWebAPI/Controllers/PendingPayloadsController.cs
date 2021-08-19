using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        // TODO
          private PendingPayloads pendingpayload1;
        public PendingPayloadsController(PendingPayloads pendingpayloads)
        {
            pendingpayload1 = pendingpayloads;
        }

        [HttpGet("/updated")]
        public IActionResult Get()
        {
            return Ok(pendingpayload1.Payloads);
        }

        [HttpPost("/newaddition")]
        public IActionResult Post(Payload payload)
        {
            pendingpayload1.Payloads.Add(payload);
            return Ok();
        }
    }
}
