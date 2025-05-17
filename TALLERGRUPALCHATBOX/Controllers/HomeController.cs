using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TALLERGRUPALCHATBOX.Interfaces;
using TALLERGRUPALCHATBOX.Models;
using TALLERGRUPALCHATBOX.Repositories;

namespace TALLERGRUPALCHATBOX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IChatBoxService _chatBoxService;
        public HomeController(ILogger<HomeController> logger, IChatBoxService chatbotservice)
        {
            _logger = logger;
            _chatBoxService = chatbotservice;
            
        }

        public async Task<IActionResult> Index()
        {
           GeminiRepository repo = new GeminiRepository();
            string answer = await _chatBoxService.GetChatbotResponse("Dame un resumen de la pelicula titanic");

            return View(answer);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
