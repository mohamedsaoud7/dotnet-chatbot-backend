
using chatbot_backend.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using chatbot_backend.ViewModels;
using chatbot_backend.Helpers;
using AutoMapper;

namespace chatbot_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VecozoController : ControllerBase
    {
        private readonly IVecozoService _vecozoService;
        private readonly IMapper _mapper;

        public VecozoController(IVecozoService vecozoService,IMapper mapper)
        {
            _mapper=mapper;
            _vecozoService = vecozoService;
        }

        [HttpPost]
        public async Task<IActionResult> GetInsurances([FromBody] VecozoSearchCriteriaVM searchCriteria, [FromHeader] string bearer) { 

            List<HealthInsuranceVecozoResult> mappedVecozoResults = new List<HealthInsuranceVecozoResult>();
            string mdmUrl = "https://wa-mdmapialpha-t.azurewebsites.net/";
            string commonURL = "https://wa-commonapialpha-t.azurewebsites.net/"; // Or get this from configuration
            var result = await _vecozoService.GetVecozoInsurances(commonURL, searchCriteria, bearer);
            mappedVecozoResults = await VecozoHelper.MapVecozoResult(result, mdmUrl, bearer, _mapper, searchCriteria.InsuranceReferenceDate);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to retrieve insurance information.");
            }
        }
    } }