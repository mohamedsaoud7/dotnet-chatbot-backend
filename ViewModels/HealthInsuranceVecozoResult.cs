namespace chatbot_backend.ViewModels
{
    public class HealthInsuranceVecozoResult
    {
        public bool IsSelected { get; set; } = true;
        public OrganizationViewModel VhiInsurer { get; set; }
        public ProductViewModel Product { get; set; }
        public string VhiPolicyType { get; set; }
        public string VhiPolicyCode { get; set; }
        public string VhiPolicyName { get; set; }
        public string VhiHealthInsuranceNumber { get; set; }
        public DateTime? VhiStartDate { get; set; }
        public DateTime? VhiEndDate { get; set; }
        public bool VhiIsManual { get; set; } = false;
        public string VhiUzovi { get; set; }
        public DateTime VhiReferenceDate { get; set; }
        public string VhiProductType { get; set; }
        public string VhiStatusPolisCheck { get; set; }
        public string coveredPerson { get; set; }
        public List<OrganizationViewModel> VhiInsurerMatches { get; set; }
        public string VhiTypePolicyCheck { get; internal set; }
        public int VhiBsn { get; internal set; }
        public string vhiAlarmcenter { get; set; }
    }
}

