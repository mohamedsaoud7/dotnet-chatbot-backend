using chatbot_backend.Data;
using chatbot_backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chatbot_backend.Repository
{
    public class DamageReasonsRepo : IDamageReasonRepo
    {
        private readonly DataContext _context;

        public DamageReasonsRepo(DataContext context)
        {
            _context = context;
        }

        async Task<List<object>> IDamageReasonRepo.GetAllNamesAsync(string cultureCode)
        {
            if (cultureCode == "EN")
            {
                return await _context.DamageReasons
                    .Select(dr => new
                    {
                        Id = dr.DrId,
                        Name = dr.DrLongName
                    })
                    .ToListAsync<object>(); // Ajout de <object> pour spécifier le type d'objet
            }
            else
            {
                return await _context.DamageReasons
                    .Join(
                        _context.LocalizedEntries,
                        dr => dr.DrLocalizableEntryId,
                        le => le.LlcLocalizableEntryId,
                        (dr, le) => new { dr, le }
                    )
                    .Where(joined => joined.le.LlcCultureCode == cultureCode)
                    .Select(joined => new
                    {
                        Id = joined.dr.DrId,
                        Name = joined.le.LlcLongTranslation
                    })
                    .ToListAsync<object>(); // Ajout de <object> pour spécifier le type d'objet
            }
        }





    }
}
