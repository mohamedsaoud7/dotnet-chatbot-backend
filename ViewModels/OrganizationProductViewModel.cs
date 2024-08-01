namespace chatbot_backend.ViewModels
{
    public class OrganizationProductViewModel
    {
        public System.Guid Id { get; set; }
        public System.Guid? OrganizationUnitId { get; set; }
        public System.Guid? OrganizationCodeTypeId { get; set; }
        public string Code { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string OuCode { get; set; }
        public string OuShortName { get; set; }
        public string OuLongName { get; set; }
        public bool IsClient { get; set; }
        public string AlphaProductType { get; set; }
        public string OrganizationCodeTypeShortName { get; set; }
        public string AlphaProductName { get; set; }
        public string AlphaProductCode { get; set; }
        public System.Guid? AlphaProductId { get; set; }
    }
}
