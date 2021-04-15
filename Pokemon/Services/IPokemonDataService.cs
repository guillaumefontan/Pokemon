namespace Pokemon.Services
{
    using Pokemon.DTO;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the <see cref="PokemonDataService"/> class.
    /// </summary>
    public interface IPokemonDataService
    {
        /// <summary>
        /// Method to obtain pokemon data.
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon for which to fetch data.</param>
        /// <returns>The <see cref="PokemonData"/> object.</returns>
        Task<PokemonData> GetPokemonData(string pokemonName);

        /// <summary>
        /// Method to obtain translated pokemon data.
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon for which to fetch data.</param>
        /// <returns>The <see cref="PokemonData"/> object.</returns>
        Task<PokemonData> GetTranslatedPokemonData(string pokemonName);
    }
}
