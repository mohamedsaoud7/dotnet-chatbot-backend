using chatbot_backend.Data;
using chatbot_backend.Interfaces;
using chatbot_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace chatbot_backend.Repository
{
    public class FallbackRepo : IFallbackRepo
    {
        private readonly LocalDbContext _context;


        public FallbackRepo(LocalDbContext context)
        {
            _context = context;
        }

        public int FallbackCount ()
        {
            return _context.Fallbacks.Count ();
        }

        public async Task<Fallback> AddAsync(Fallback fallback)
        {
            _context.Fallbacks.Add(fallback);
            await _context.SaveChangesAsync();
            return fallback;
        }

        public async Task<IEnumerable<Fallback>> GetAllAsync()
        {
            return await _context.Fallbacks.ToListAsync();
        }
    }
}
