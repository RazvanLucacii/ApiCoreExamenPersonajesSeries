using ApiCoreExamenPersonajesSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreExamenPersonajesSeries.Data
{
    public class PersonajesSeriesContext : DbContext
    {
        public PersonajesSeriesContext(DbContextOptions<PersonajesSeriesContext> options)
        : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }

    }
}
