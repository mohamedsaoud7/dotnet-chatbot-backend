using chatbot_backend.DTO;

namespace chatbot_backend.IServices
{
    public interface IDraftFormService
    {
        Task<IEnumerable<CaseTypeCountDto>> GetCaseTypeCountsAsync();

        Task<IEnumerable<CountryCountDto>> GetCountryCountsAsync();
    }
}
