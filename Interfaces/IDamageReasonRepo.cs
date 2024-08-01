namespace chatbot_backend.Interfaces
{
    public interface IDamageReasonRepo
    {
        Task<List<Object>> GetAllNamesAsync(string cultureCode);
    }
}
