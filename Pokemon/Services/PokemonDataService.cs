namespace Pokemon.Services
{
    using Pokemon.DTO;
    using Pokemon.Helpers;
    using Pokemon.Repositories;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Service for obtaining pokemon data.
    /// </summary>
    public class PokemonDataService : IPokemonDataService
    {
        private readonly IPokemonDataRepository pokemonDataRepository;
        private readonly IPokemonDataParser pokemonDataParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonDataService"/> class.
        /// </summary>
        /// <param name="pokemonDataRepository">An instance of <see cref="IPokemonDataRepository"/>.</param>
        /// <param name="pokemonDataParser">An instance of <see cref="IPokemonDataParser"/>.</param>
        public PokemonDataService(
            IPokemonDataRepository pokemonDataRepository,
            IPokemonDataParser pokemonDataParser)
        {
            this.pokemonDataRepository = pokemonDataRepository;
            this.pokemonDataParser = pokemonDataParser;
        }
        
        /// <inheritdoc/>
        public async Task<PokemonData> GetPokemonData(string pokemonName)
        {
            //TODO : validate pokemonName exists by cross checking against data obtained from
            //https://pokeapi.co/api/v2/pokemon?limit=10000 (arbitrary upper limit of known pokemon, currently 1118)

            PokemonSpeciesData response = await this.pokemonDataRepository.GetPokemonData(pokemonName);

            return this.pokemonDataParser.BuildPokemonData(response);
        }

        /// <inheritdoc/>
        public async Task<PokemonData> GetTranslatedPokemonData(string pokemonName)
        {
            //TODO : validate pokemonName exists by cross checking against data obtained from
            //https://pokeapi.co/api/v2/pokemon?limit=10000 (arbitrary upper limit of known pokemon, currently 1118)

            PokemonSpeciesData response = await this.pokemonDataRepository.GetPokemonData(pokemonName);

            PokemonData data = this.pokemonDataParser.BuildPokemonData(response);

            if (data.Habitat == "cave" || data.IsLegendary)
            {
                try
                {
                    TranslationResponse translation = await this.pokemonDataRepository.GetTranslation(data.Description, "yoda");
                    data.Description = translation.Contents.Translated;
                }
                catch (Exception)
                {
                    //TODO : Add logging
                }
            }
            else
            {
                try
                {
                    TranslationResponse translation = await this.pokemonDataRepository.GetTranslation(data.Description, "shakespeare");
                    data.Description = translation.Contents.Translated;
                }
                catch (Exception)
                {
                    //TODO : Add logging
                }
            }

            return data;
        }
    }
}

