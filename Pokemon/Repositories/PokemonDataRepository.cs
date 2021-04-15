namespace Pokemon.Repositories
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Pokemon.Configuration;
    using Pokemon.DTO;
    using Pokemon.Helpers;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository for obtaining pokemon data.
    /// </summary>
    public class PokemonDataRepository : IPokemonDataRepository
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<PokemonConfiguration> pokemonConfig;
        private readonly IRequestBuilder requestBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonDataRepository"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/>.</param>
        /// <param name="pokemonConfig">An instance of <see cref="PokemonConfiguration"/>.</param>
        /// <param name="requestBuilder">An instance of <see cref="IRequestBuilder"/>.</param>
        public PokemonDataRepository(HttpClient httpClient, IOptions<PokemonConfiguration> pokemonConfig, IRequestBuilder requestBuilder)
        {
            this.httpClient = httpClient;
            this.pokemonConfig = pokemonConfig;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc/>
        public async Task<PokemonSpeciesData> GetPokemonData(string pokemonName)
        {
            string uri = $"{this.pokemonConfig.Value.PokeAPIURL}pokemon-species/{pokemonName}";
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            //TODO : Create class to validate response

            return JsonConvert.DeserializeObject<PokemonSpeciesData>(await response.Content.ReadAsStringAsync());
        }

        /// <inheritdoc/>
        public async Task<TranslationResponse> GetTranslation(string description, string language)
        {
            string uri = $"{this.pokemonConfig.Value.FunTranslationsURL}{language}.json";

            HttpContent request = this.requestBuilder.BuildTranslationRequest(description);

            HttpResponseMessage response = await httpClient.PostAsync(uri, request);

            //TODO : Create class to validate response

            return JsonConvert.DeserializeObject<TranslationResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}