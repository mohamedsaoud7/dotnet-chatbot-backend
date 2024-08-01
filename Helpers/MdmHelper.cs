using chatbot_backend.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace chatbot_backend.Helpers
{
    public class MdmHelper
    {
        public static async Task<IEnumerable<OrganizationProductViewModel>> GetInsurerByUzoviCodeAndProduct(string urlMdmAPI, int uzoviCode, string productCode, string bearer)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer.Replace("Bearer ", ""));
                string json = JsonConvert.SerializeObject(new
                {
                    UzoviCode = uzoviCode,
                    ProductCode = productCode
                });
                var httpContent = new StringContent(json, Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var results = await client.PostAsync(urlMdmAPI + $"api/OrganizationUnit/GetInsurersClientByOrganizationCodeByUzoviCode", httpContent);
                if (results.IsSuccessStatusCode)
                {
                    var orgranizationProduct = JsonConvert.DeserializeObject<IEnumerable<OrganizationProductViewModel>>(results.Content.ReadAsStringAsync().Result);
                    return orgranizationProduct;
                }
                else
                {
                    return new List<OrganizationProductViewModel>();
                }
            }

        }
    }
}
