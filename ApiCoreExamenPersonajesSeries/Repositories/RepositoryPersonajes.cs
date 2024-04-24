using ApiCoreExamenPersonajesSeries.Data;
using ApiCoreExamenPersonajesSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreExamenPersonajesSeries.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesSeriesContext context;

        public RepositoryPersonajes(PersonajesSeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesSeriesAsync(string serie)
        {
            return await this.context.Personajes.Where(z => z.Serie == serie).ToListAsync();
        }

        public async Task<List<string>> GetSeriesAsync()
        {
            var consulta = (from datos in this.context.Personajes
                            select datos.Serie).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<Personaje> GetPersonajeAsync(int idpersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(z => z.IdPersonaje == idpersonaje);
        }

        public async Task InsertPersonajeAsync(int idpersonaje, string nombre, string imagen, string serie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = idpersonaje;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Serie = serie;
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int idpersonaje, string nombre, string imagen, string serie)
        {

            Personaje personaje = await this.GetPersonajeAsync(idpersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.Serie = serie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            Personaje personaje = await this.GetPersonajeAsync(idpersonaje);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
