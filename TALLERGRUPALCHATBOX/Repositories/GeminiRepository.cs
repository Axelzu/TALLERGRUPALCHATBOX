using TALLERGRUPALCHATBOX.Interfaces;

namespace TALLERGRUPALCHATBOX.Repositories
{
    public class GeminiRepository : IChatBoxService
    {
        HttpClient _httpClient;
        private string apiKey = "AIzaSyAYWNhmxhY1OrQLShuozsXcrMitSMmlFcE"
        public GeminiRepository()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetChatbotResponse(string prompt)
        {
            throw new NotImplementedException();
        }
    }
}
