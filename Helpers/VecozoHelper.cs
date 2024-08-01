using AutoMapper;
using chatbot_backend.Enums;
using chatbot_backend.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace chatbot_backend.Helpers
{
    public class VecozoHelper
    {
        public async static Task<List<HealthInsuranceVecozoResult>> MapVecozoResult(VecozoResult vecozoResult, string urlMdmAPI, string bearer, IMapper mapper, DateTime incidentDate)
        {
            List<HealthInsuranceVecozoResult> healthInsurances = new List<HealthInsuranceVecozoResult>();
            if (vecozoResult == null || vecozoResult.Insurer == null)
            {
                return new List<HealthInsuranceVecozoResult>();
            }

            bool hasAanvullendInsurances = vecozoResult.Insurer.Insurances
                .Where(insurance => insurance.InsuranceType == VecozoInsuranceType.Aanvullend || insurance.InsuranceType == VecozoInsuranceType.AanvullendPlusTand).Count() > 0;

            foreach (var insurance in vecozoResult.Insurer.Insurances)
            {
                OrganizationViewModel insurer = null;
                bool isClient = false;
                var product = new ProductViewModel();
                var insurerMatches = new List<OrganizationViewModel>();
                string vhiProductType = null;


                var organizationProducts = await MdmHelper.GetInsurerByUzoviCodeAndProduct(urlMdmAPI, insurance.InsurerNumber, insurance.InsurancePackageCode, bearer);
                if (organizationProducts.Count() == 1)
                {
                    var organizationProduct = organizationProducts.First();
                    insurer = mapper.Map<OrganizationViewModel>(organizationProduct);
                    product = mapper.Map<ProductViewModel>(organizationProduct);
                    isClient = organizationProduct.IsClient;
                    product.ProductType = organizationProduct.AlphaProductType;
                    vhiProductType = organizationProduct.AlphaProductType;
                }
                else
                {
                    insurerMatches = mapper.Map<List<OrganizationViewModel>>(organizationProducts);
                }

                bool isInsurerFound = insurer != null;
                healthInsurances.Add(new HealthInsuranceVecozoResult()
                {
                    VhiInsurer = isInsurerFound ? insurer : new OrganizationViewModel(),
                    Product = product,
                    VhiInsurerMatches = insurerMatches,
                    VhiPolicyName = insurance.InsurancePackageName,
                    VhiHealthInsuranceNumber = insurance.InsureeNumber,
                    VhiEndDate = insurance.EndDate,
                    VhiStartDate = insurance.StartDate,
                    VhiPolicyCode = insurance.InsurancePackageCode,
                    VhiUzovi = insurance.InsurerNumber.ToString(),
                    VhiReferenceDate = incidentDate,
                    VhiPolicyType = insurance.InsuranceType.ToString(),
                    VhiProductType = insurance.InsuranceType.ToString(),
                    VhiTypePolicyCheck = PolicyTypeCheck.PCOnline,
                    VhiStatusPolisCheck = GetStatusPolicyCheckForVecozoInsurance(isClient, isInsurerFound, hasAanvullendInsurances, insurance.InsuranceType),
                    VhiBsn = vecozoResult.Insurer.FiscalNumber,
                    coveredPerson = GetVecozoInsureeLastName(vecozoResult.Insurer),
                    vhiAlarmcenter = (isInsurerFound && insurer.Id != null) ? await GetVecozoAlaramcenters(urlMdmAPI, insurer.Id, bearer) : null
                });

            }

            return healthInsurances;
        }
        public static string GetVecozoInsureeLastName(VecozoInsuree vecozoInsuree)
        {
            if (vecozoInsuree.Perfix != null && vecozoInsuree.Lastname != null)
                return $"{vecozoInsuree.Perfix} {vecozoInsuree.Lastname}";

            return vecozoInsuree.Perfix ?? vecozoInsuree.Lastname;
        }
        public static string GetStatusPolicyCheckForVecozoInsurance(bool isClient, bool isInsurerFound, bool hasAanvullendInsurances, VecozoInsuranceType insuranceType)
        {

            if (isClient)
            {
                if (hasAanvullendInsurances && insuranceType == VecozoInsuranceType.Basis)
                    return PolicyCheckStatus.NotApplicable;

                return PolicyCheckStatus.StillToBeCheck;
            }

            return PolicyCheckStatus.NotApplicable;
        }
        public static async Task<string> GetVecozoAlaramcenters(string urlMdmAPI, Guid? insurerId, string bearer)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer.Replace("Bearer ", ""));
                var results = await client.GetAsync(urlMdmAPI + "/api/OrganizationUnit/GetInsurerAlarmCenters?InsurerId=" + insurerId);
                if (results.IsSuccessStatusCode)
                {
                    var alarmCenter = JsonConvert.DeserializeObject<List<AlarmCenterViewModel>>(results.Content.ReadAsStringAsync().Result);
                    return string.Join(";", alarmCenter.Select(a => a.alarmcenter).ToList());
                }
                else
                {
                    return null;
                }
            }
        }

    }
   
    
}
