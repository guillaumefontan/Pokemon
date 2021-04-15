namespace Pokemon.DTO
{

    using Newtonsoft.Json;

    /// <summary>
    /// Pokemon data object.
    /// </summary>
    public class PokemonData
    {
        /// <summary>
        /// Gets or sets the pokemon name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pokemon description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the pokemon habitat.
        /// </summary>
        [JsonProperty(PropertyName = "habitat")]
        public string Habitat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pokemon is legendary.
        /// </summary>
        [JsonProperty(PropertyName = "isLegendary")]
        public bool IsLegendary { get; set; }
    }
}
