using chatbot_backend.DTO;
using chatbot_backend.Interfaces;
using chatbot_backend.IServices;
using chatbot_backend.Models;
using chatbot_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace chatbot_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _IFeedbackService;
        private readonly IFeedbackRepo _IFeedbackRepo;

        public FeedbackController(IFeedbackService IFeedbackService, IFeedbackRepo IFeedbackRepo)
        {
            _IFeedbackService = IFeedbackService;
            _IFeedbackRepo = IFeedbackRepo;

        }
        [HttpPost("message/{text}")]
        public async Task<IActionResult> ClassifyText(string text)
        {
            try
            {
                var result = await _IFeedbackService.ClassifyAndSaveTextAsync(text);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAll")]

        public async Task<ActionResult<IEnumerable<Feedback>>> GetAll()
        {
            try
            {
                var result = await _IFeedbackRepo.GetAllAsync();

                return Ok(result);

            }
            catch(HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteFeedback(int id)
        {
            await _IFeedbackRepo.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("summary")]
        public ActionResult<FeedbackSummaryDto> GetFeedbackSummary()
        {
            var summary = _IFeedbackService.GetFeedbackSummary();
            return Ok(summary);
        }
    }
}

