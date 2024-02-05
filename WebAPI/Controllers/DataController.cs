using Microsoft.AspNetCore.Http;
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
                    return Ok(res);
                }
                else if (input.Operation == "getPairs") {
                    Dictionary<Int64, Int64> map = await _arrayHandlerService.GetPairs();
                    return Ok();
                }
                else
                    return BadRequest(new { Error = "Invalid operation!" });
            }
            catch(Exception ex) { 
                return StatusCode(500, new { Error = ex.Message});
            }
        }
    }
}
