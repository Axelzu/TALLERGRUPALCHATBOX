using System;

namespace TALLERGRUPALCHATBOX.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string RespuestaTexto { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string GuardadoPor { get; set; }
    }
}
