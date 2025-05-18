using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TALLERGRUPALCHATBOX.Interfaces;
using TALLERGRUPALCHATBOX.Models;
using Microsoft.Extensions.Logging;
using TALLERGRUPALCHATBOX.Data; // Para ApplicationDbContext
using System;
using System.Threading.Tasks;

namespace TALLERGRUPALCHATBOX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatBoxService _chatBoxService;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IChatBoxService chatBoxService, ApplicationDbContext context)
        {
            _logger = logger;
            _chatBoxService = chatBoxService;
            _context = context;
        }

        public async Task<IActionResult> Index(string? prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                prompt = "Hola, ¿en qué puedo ayudarte?";
            }

            string respuesta = await _chatBoxService.GetChatbotResponse(prompt);

            // Guardar en la base de datos
            var nuevaRespuesta = new Respuesta
            {
                RespuestaTexto = respuesta,
                Fecha = DateTime.Now,
                Proveedor = _chatBoxService.GetType().Name, // O puedes usar un string fijo como "Groq"
                GuardadoPor = "UsuarioTest" // Puedes cambiar esto por un usuario real si tienes autenticación
            };

            _context.Respuestas.Add(nuevaRespuesta);
            await _context.SaveChangesAsync();

            var model = new ChatbotViewModel
            {
                ResponseText = respuesta
            };

            return View(model);
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
