using chatbot_backend.Interfaces;
using chatbot_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace chatbot_backend.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FallbackController : ControllerBase
    {
        private readonly IFallbackRepo _fallbackRepo;

        public FallbackController(IFallbackRepo fallbackRepo) {
            _fallbackRepo = fallbackRepo;
        }
        [HttpPost]

        public async Task<ActionResult<Fallback>> PostFallback([FromBody] Fallback fallback)
        {
            try
            {
                await _fallbackRepo.AddAsync(fallback);
                return CreatedAtAction(nameof(PostFallback), new { id = fallback.Id }, fallback);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // Or use a proper logger like Serilog or NLog

                // Return a more informative error response
                return BadRequest(new { message = "Failed to add fallback record.", error = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Fallback>>> GetAll()
        {
            try
            {
                var result = await _fallbackRepo.GetAllAsync();

                return Ok(result);
            }
            catch (HttpRequestException ex) {
                
                return BadRequest(ex.Message);
            }
            

        }
        [HttpGet("total")]
        public ActionResult<int> GetFallbackCounts()
        {
            var total = _fallbackRepo.FallbackCount();
            return Ok(total);

        }
    }
}
