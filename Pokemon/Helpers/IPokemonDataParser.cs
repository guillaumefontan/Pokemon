namespace Pokemon.Helpers
{
    using Pokemon.DTO;

    public interface IPokemonDataParser
    {
        /// <summary>
        /// Method to build pokemon data.
        /// </summary>
        /// <param name="pokemonSpeciesData">Data obtained from PokeAPI.</param>
        /// <returns>Pokemon data.</returns>
        PokemonData BuildPokemonData(PokemonSpeciesData pokemonSpeciesData);
    }
}