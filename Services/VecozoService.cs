using chatbot_backend.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using chatbot_backend.ViewModels;

namespace chatbot_backend.Services
{
    public class VecozoService : IVecozoService
    {
        private readonly HttpClient _httpClient;

        public VecozoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<VecozoResult> GetVecozoInsurances(string commonURL, VecozoSearchCriteriaVM vecozoSearch, string bearer)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer.Replace("Bearer ", ""));

            string json = JsonConvert.SerializeObject(vecozoSearch);
            var httpContent = new StringContent(json, Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var results = await _httpClient.PostAsync(commonURL + "/vecozo/search", httpContent);

            if (results.IsSuccessStatusCode)
            {
                var vecozoResults = JsonConvert.DeserializeObject<VecozoResult>(await results.Content.ReadAsStringAsync());
                return vecozoResults;
            }
            else
            {
                return null;
            }

        }
    }
}
