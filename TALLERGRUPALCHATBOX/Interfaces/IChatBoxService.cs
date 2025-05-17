namespace TALLERGRUPALCHATBOX.Interfaces
{
    public interface IChatBoxService
    {
        public Task<string> GetChatbotResponse(string prompt);
    }
}
