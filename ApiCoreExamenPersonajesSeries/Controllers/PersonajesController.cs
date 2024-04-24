using ApiCoreExamenPersonajesSeries.Models;
using ApiCoreExamenPersonajesSeries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreExamenPersonajesSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Personajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("[action]/{serie}")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSeries(string serie)
        {
            return await this.repo.GetPersonajesSeriesAsync(serie);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Series()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.GetPersonajeAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> InsertPersonaje(Personaje pj)
        {
            await this.repo.InsertPersonajeAsync(pj.IdPersonaje, pj.Nombre, pj.Imagen, pj.Serie);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdatePersonaje(Personaje pj)
        {
            await this.repo.UpdatePersonajeAsync(pj.IdPersonaje, pj.Nombre, pj.Imagen, pj.Serie);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            if (await this.repo.GetPersonajeAsync(id) == null)
            {
                return NotFound();
            }
            else
            {
                await this.repo.DeletePersonajeAsync(id);
                return Ok();
            };
        }
    }
}
