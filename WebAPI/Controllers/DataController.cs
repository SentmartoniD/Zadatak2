﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IArrayHandler _arrayHandlerService;

        public DataController(IArrayHandler arrayHandlerService)
        {
            _arrayHandlerService = arrayHandlerService;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> Upload([FromBody] Input input)
        {
            try {
                if (input.Operation == "deduplicate")
                {
                    Output res = await _arrayHandlerService.Deduplicate(input.Data);
                    return Ok(new { Output = res});
                }
                else if (input.Operation == "getPairs") {
                    OutputMap res = await _arrayHandlerService.GetPairs(input.Data);
                    return Ok(new { Output = res });
                }
                else
                    return BadRequest(new { Error = $"Operation with name: {input.Operation} doesnt exist!" });
            }
            catch(Exception ex) { 
                return StatusCode(500, new { Error = ex.Message});
            }
        }
    }
}
