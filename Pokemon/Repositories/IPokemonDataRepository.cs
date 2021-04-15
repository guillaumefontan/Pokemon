namespace Pokemon.Repositories
{
    using Pokemon.DTO;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the <see cref="PokemonDataRepository"/> class.
    /// </summary>
    public interface IPokemonDataRepository
    {
        /// <summary>
        /// Method to obtain pokemon data.
        /// </summary>
        /// <param name="pokemonName">Name of the pokemon for which to fetch data.</param>
        /// <returns>The <see cref="PokemonSpeciesData"/> object.</returns>
        Task<PokemonSpeciesData> GetPokemonData(string pokemonName);

        /// <summary>
        /// Method to obtain translated description.
        /// </summary>
        /// <param name="description">String to translate.</param>
        /// <param name="language">Language to translate in.</param>
        /// <returns>The <see cref="PokemonSpeciesData"/> object.</returns>
        Task<TranslationResponse> GetTranslation(string description, string language);
    }
}
