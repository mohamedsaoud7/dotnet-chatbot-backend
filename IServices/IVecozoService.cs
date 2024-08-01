using chatbot_backend.ViewModels;
namespace chatbot_backend.IServices
{
    public interface IVecozoService
    {
        Task<VecozoResult> GetVecozoInsurances(string commonURL, VecozoSearchCriteriaVM vecozoSearch, string bearer);
    }
}
