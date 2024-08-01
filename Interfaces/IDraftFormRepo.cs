using chatbot_backend.Models;

namespace chatbot_backend.Interfaces
{
    public interface IDraftFormRepo
    {

        Task AddAsync(DraftForm draftForm);

        Task<IEnumerable<DraftForm>> GetAllDraftFormsAsync();

    }
}
