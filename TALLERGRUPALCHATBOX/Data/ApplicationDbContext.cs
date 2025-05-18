using Microsoft.EntityFrameworkCore;
using TALLERGRUPALCHATBOX.Models;

namespace TALLERGRUPALCHATBOX.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Respuesta> Respuestas { get; set; }
    }
}
