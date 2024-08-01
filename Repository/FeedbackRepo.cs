using chatbot_backend.Controllers;
using chatbot_backend.Data;
using chatbot_backend.Interfaces;
using chatbot_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Repository
{
    public class FeedbackRepo : IFeedbackRepo
    {
        private readonly LocalDbContext _context;

        public FeedbackRepo(LocalDbContext context)
        {
            _context = context;
        }
        public async Task<Feedback> AddAsync(Feedback Feedback)
        {
            _context.Feedbacks.Add(Feedback);
            await _context.SaveChangesAsync();
            return Feedback;
        }

        public async Task DeleteAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }
    }
}
