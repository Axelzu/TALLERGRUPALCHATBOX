using System.Text.Json.Serialization;

namespace TALLERGRUPALCHATBOX.Models
{
    public class GeminiResponse
    {
        [JsonPropertyName("candidates")]
        public List<Candidate> Candidates { get; set; }
    }

    public class Candidate
    {
        [JsonPropertyName("content")]
        public ContentResponse Content { get; set; }
    }

    public class ContentResponse
    {
        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; }
    }

}
