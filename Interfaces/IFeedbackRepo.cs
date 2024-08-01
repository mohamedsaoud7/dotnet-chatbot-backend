using chatbot_backend.Controllers;
using chatbot_backend.Models;

namespace chatbot_backend.Interfaces
{
    public interface IFeedbackRepo
    {
        Task<Feedback> AddAsync(Feedback Feedback);
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task DeleteAsync(int id);



    }
}
