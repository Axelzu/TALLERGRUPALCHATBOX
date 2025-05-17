using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TALLERGRUPALCHATBOX.Models;
using TALLERGRUPALCHATBOX.Repositories;

namespace TALLERGRUPALCHATBOX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           GeminiRepository repo = new GeminiRepository();
            string answer = await repo.GetChatbotResponse("Dame un resumen de la pelicula titanic");

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
