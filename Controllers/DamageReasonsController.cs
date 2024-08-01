using chatbot_backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace chatbot_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageReasonsController : ControllerBase
    {
        private readonly IDamageReasonRepo _repository;
        public DamageReasonsController(IDamageReasonRepo repository)
        {
            _repository = repository;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<string>>> GetAll(string cultureCode)
        {
            var names = await _repository.GetAllNamesAsync(cultureCode);
            return Ok(names);
        }
    }
}
