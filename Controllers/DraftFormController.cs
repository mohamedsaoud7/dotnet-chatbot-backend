using chatbot_backend.DTO;
using chatbot_backend.Interfaces;
using chatbot_backend.IServices;
using chatbot_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace chatbot_backend.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class DraftFormController : ControllerBase
    {
        private readonly IDraftFormRepo _draftFormRepo;
        private readonly IDraftFormService _draftFormService;

        public DraftFormController(IDraftFormRepo draftFormRepo,IDraftFormService draftFormService)
        {
            _draftFormRepo = draftFormRepo;
            _draftFormService = draftFormService;
        }
        [HttpPost]
        public async Task<IActionResult> PostDraftForm([FromBody] DraftForm draftForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _draftFormRepo.AddAsync(draftForm);
            return CreatedAtAction(nameof(PostDraftForm), new { id = draftForm.DrfId }, draftForm);
        }
        [HttpGet("case-type-counts")]
        public async Task<ActionResult<IEnumerable<CaseTypeCountDto>>> GetCaseTypeCounts()
        {
            var counts = await _draftFormService.GetCaseTypeCountsAsync();
            return Ok(counts);
        }
        [HttpGet("country-counts")]
        public async Task<ActionResult<IEnumerable<CaseTypeCountDto>>> GetCountryCounts()
        {
            var counts = await _draftFormService.GetCountryCountsAsync();
            return Ok(counts);
        }
    }
}
