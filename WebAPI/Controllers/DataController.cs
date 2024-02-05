using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<ActionResult> Upload([FromBody] Input input)
        {
            try {
                if (input.Operation == "deduplicate")
                {
                    return Ok(new { Message = "Successfull upload!" });
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
