using chatbot_backend.Models;

namespace chatbot_backend.Interfaces
{
    public interface IFallbackRepo
    {
        Task<Fallback> AddAsync(Fallback fallback);

        Task<IEnumerable<Fallback>> GetAllAsync();

        int FallbackCount();
    }
}
