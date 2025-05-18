using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TALLERGRUPALCHATBOX.Interfaces;

namespace TALLERGRUPALCHATBOX.Repositories
{
    public class OpenAIRepository : IChatBoxService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "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"; // <-- Pega aquí tu API Key de Groq

        public OpenAIRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://api.groq.com/openai/v1/chat/completions";

            var requestBody = new
            {
                model = "llama3-70b-8192", // Modelo recomendado por Groq
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(jsonResponse);
            var contentText = document.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return contentText ?? "No hubo respuesta.";
        }
    }
}
