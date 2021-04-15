namespace Pokemon.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Pokemon.DTO;
    using Pokemon.Services;

    /// <summary>
    /// Controller to obtain Pokemon data.
    /// </summary>
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonDataService pokemonDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonController"/> class.
        /// </summary>
        /// <param name="pokemonDataService">An instance of <see cref="PokemonDataService"/>.</param>
        public PokemonController(
            IPokemonDataService pokemonDataService)
        {
            this.pokemonDataService = pokemonDataService;
        }

        /// <summary>
        /// Endpoint to obtain data on a pokemon.
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon for which to fetch the data.</param>
        /// <returns>The <see cref="PokemonData"/> object.</returns>
        [HttpGet]
        [Route("/[Controller]/{pokemonName}")]
        public async Task<PokemonData> GetPokemonData(string pokemonName)
        {
            return await this.pokemonDataService.GetPokemonData(pokemonName);
        }

        /// <summary>
        /// Endpoint to obtain translated data on a pokemon.
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon for which to fetch the data.</param>
        /// <returns>The <see cref="PokemonData"/> object.</returns>
        [HttpGet]
        [Route("/[Controller]/translated/{pokemonName}")]
        public async Task<PokemonData> GetTranslatedPokemonData(string pokemonName)
        {
            return await this.pokemonDataService.GetTranslatedPokemonData(pokemonName);
        }
    }
}
