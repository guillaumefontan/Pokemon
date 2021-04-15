namespace Pokemon.Helpers
{
    using Pokemon.DTO;
    using System.Linq;

    public class PokemonDataParser : IPokemonDataParser
    {
        /// <inheritdoc/>
        public PokemonData BuildPokemonData(PokemonSpeciesData pokemonSpeciesData)
        {
            return new PokemonData()
            {
                Name = pokemonSpeciesData.Name,
                Habitat = pokemonSpeciesData.Habitat.Name,
                Description = pokemonSpeciesData.Description.FirstOrDefault(x => x.DescriptionLanguage.Language == "en").FlavorText,
                IsLegendary = pokemonSpeciesData.IsLegendary
            };
        }
    }
}
