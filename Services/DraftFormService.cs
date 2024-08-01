using chatbot_backend.Data;
using chatbot_backend.DTO;
using chatbot_backend.Interfaces;
using chatbot_backend.IServices;
using Newtonsoft.Json;

namespace chatbot_backend.Services
{
    public class DraftFormService : IDraftFormService
    {
        private readonly IDraftFormRepo _repository;
        private readonly ILogger<DraftFormService> _logger;

        public DraftFormService(IDraftFormRepo repository, ILogger<DraftFormService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<IEnumerable<CaseTypeCountDto>> GetCaseTypeCountsAsync()
        {
            var draftForms = await _repository.GetAllDraftFormsAsync();
            var caseTypeCounts = new List<CaseTypeCountDto>();

            foreach (var draftForm in draftForms)
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(draftForm.DrfJson);
                    var idCaseType = jsonData["IdCaseType"].ToString();

                    var caseType = caseTypeCounts.FirstOrDefault(ct => ct.IdCaseType == idCaseType);
                    if (caseType == null)
                    {
                        caseTypeCounts.Add(new CaseTypeCountDto
                        {
                            IdCaseType = idCaseType,
                            Count = 1
                        });
                    }
                    else
                    {
                        caseType.Count++;
                    }
                }
                catch (JsonReaderException ex)
                {
                    _logger.LogError($"Error parsing JSON for DraftForm with ID {draftForm.DrfId}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Unexpected error processing DraftForm with ID {draftForm.DrfId}: {ex.Message}");
                }
            }

            return caseTypeCounts;
        }

        public async Task<IEnumerable<CountryCountDto>> GetCountryCountsAsync()
        {
            var draftForms = await _repository.GetAllDraftFormsAsync();
            var CountryCounts = new List<CountryCountDto>();

            foreach (var draftForm in draftForms)
            {
                try
                {
                    var jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(draftForm.DrfJson);
                    if (jsonData != null && jsonData.TryGetValue("country", out var countryValue) && countryValue != null)
                    {
                        var Country = countryValue.ToString();
                        var caseType = CountryCounts.FirstOrDefault(ct => ct.Country == Country);

                        if (caseType == null)
                        {
                            CountryCounts.Add(new CountryCountDto
                            {
                                Country = Country,
                                Count = 1
                            });
                        }
                        else
                        {
                            caseType.Count++;
                        }
                    }
                }
                catch (JsonReaderException ex)
                {
                    _logger.LogError($"Error parsing JSON for DraftForm with ID {draftForm.DrfId}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Unexpected error processing DraftForm with ID {draftForm.DrfId}: {ex.Message}");
                }
            }

            return CountryCounts;
        }
    }
}
