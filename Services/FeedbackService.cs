using chatbot_backend.Controllers;
using chatbot_backend.Data;
using chatbot_backend.DTO;
using chatbot_backend.Interfaces;
using chatbot_backend.IServices;
using chatbot_backend.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SendGrid.Helpers.Mail;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_backend.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepo _repository;
        private readonly LocalDbContext _context;
        private readonly HttpClient _httpClient;
        public FeedbackService(IFeedbackRepo repository,HttpClient httpClient,LocalDbContext context)
        {
            _httpClient = httpClient;
            _repository = repository;  
            _context = context;
        }
        public async Task<Feedback> ClassifyAndSaveTextAsync(string text)
        {
            var flaskApiUrl = "http://localhost:5002/classify";
            var content = new StringContent($"{{\"text\":\"{text}\"}}", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(flaskApiUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Erreur lors de l'appel à l'API Flask: {response.StatusCode}");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var classificationResult = JArray.Parse(responseString)[0];

            var label = classificationResult["label"].ToString();
            var score = (float)classificationResult["score"];

            // Enregistrer les données dans la base de données via le repository
            var Feedback = new Feedback
            {
                Text = text,
                Label = label,
                Score = score
            };

            await _repository.AddAsync(Feedback);

            return Feedback;
        }
        public FeedbackSummaryDto GetFeedbackSummary()
        {
            var totalFeedbacks = _context.Feedbacks.Count();
            var positiveFeedbacks = _context.Feedbacks.Count(f => f.Label == "POSITIVE");
            var negativeFeedbacks = _context.Feedbacks.Count(f => f.Label == "NEGATIVE");

            return new FeedbackSummaryDto
            {
                TotalFeedbacks = totalFeedbacks,
                PositiveFeedbacks = positiveFeedbacks,
                NegativeFeedbacks = negativeFeedbacks
            };
        }

    }
    }

