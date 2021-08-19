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
    public class BlocksController : ControllerBase
    {
        // TODO
         private BlockList lista;

        public BlocksController(BlockList blockList)
        {
            lista = blockList;
        }


        [HttpGet("/blocks")]
        public IActionResult Get()
        {
            return Ok(lista.Chain.Select(blk => new BlockSummary()
            {
                Hash = blk.Hash,
                PreviousHash = blk.PreviousHash,
                TimeStamp = blk.TimeStamp,
                
            })); 
        }

        
        [HttpGet("/blocks/{hash?}")]
        public IActionResult GetBlock(string hash)
        {
            var block = lista.Chain
                .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(blk => new BlockSummary()
                    {
                        Hash = blk.Hash,
                        PreviousHash = blk.PreviousHash,
                        TimeStamp = blk.TimeStamp
                        
                    })
                    .First());
            }

            return null;
        }

        [HttpGet("/ blocks /{hash ?}/Payloads")]
        public IActionResult GetBlockPayload(string Hash)
        {
            var block = lista.Chain
                        .Where(block => block.Hash.Equals(Hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => block.Data
                    )
                    .First());
            }

            return null;
        }
    }
}
