using TALLERGRUPALCHATBOX.Interfaces;
using TALLERGRUPALCHATBOX.Models;

namespace TALLERGRUPALCHATBOX.Repositories
{
    public class GeminiRepository : IChatBoxService
    {
        HttpClient _httpClient;
        private string apiKey = "AIzaSyAYWNhmxhY1OrQLShuozsXcrMitSMmlFcE";
        public GeminiRepository()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=" + apiKey;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);
            GeminiRequest request = new GeminiRequest
            {
                Contents = new List<Content> 
                {
                    new Content
                    {
                        Parts=  new List<Part>
                        {
                            new Part
                            {
                                Text= prompt
                            }
                        }
                    }
                }  
            };
        }
    }
}
