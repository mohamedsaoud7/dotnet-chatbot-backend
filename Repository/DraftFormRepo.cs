using chatbot_backend.Data;
using chatbot_backend.Interfaces;
using chatbot_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Repository

{
    public class DraftFormRepo : IDraftFormRepo
    {
        private readonly DataContext _context;
        public DraftFormRepo(DataContext context)
        {
            _context = context;

        }
        public async Task AddAsync(DraftForm draftForm)
        {
            await _context.Set<DraftForm>().AddAsync(draftForm);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DraftForm>> GetAllDraftFormsAsync()
        {
            return await _context.DraftForms.ToListAsync();
        }
    }
}
