﻿using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        // TODO
         public BlockList lista;

        public BlocksController(BlockList blockList)
        {
            lista = blockList;
        }


        [HttpGet("/blocks")]
        public IActionResult Get()
        {
            return Ok(lista.Chain.Select(a => new BlockSummary()
            {
                Hash = a.Hash,
                PreviousHash = a.PreviousHash,
                TimeStamp = a.TimeStamp,
                
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
                    .Select(block1 => new BlockSummary()
                    {
                        Hash = block1.Hash,
                        PreviousHash = block1.PreviousHash,
                        TimeStamp = block1.TimeStamp,
                        
                    }
                    )
                    .First());
            }

            return null;
        }

        [HttpGet("/ blocks /{hash ?}/payloads")]
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
