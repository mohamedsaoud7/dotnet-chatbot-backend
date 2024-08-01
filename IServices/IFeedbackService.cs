using chatbot_backend.Controllers;
using chatbot_backend.DTO;
using chatbot_backend.Models;

namespace chatbot_backend.IServices
{
    public interface IFeedbackService
    {
        Task<Feedback> ClassifyAndSaveTextAsync(string text);

        FeedbackSummaryDto GetFeedbackSummary();
    }
}
