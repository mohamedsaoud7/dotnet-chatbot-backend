namespace chatbot_backend.ViewModels
{
    public class OrganizationViewModel
    {
        public Guid? Id { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string LongName { get; set; }
        public bool isClient { get; set; }
    }
}