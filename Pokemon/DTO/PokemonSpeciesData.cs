namespace Pokemon.DTO
{

    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Response object for pokemon species.
    /// </summary>
    public class PokemonSpeciesData
    {
        /// <summary>
        /// Gets or sets the pokemon name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pokemon habitat.
        /// </summary>
        [JsonProperty(PropertyName = "habitat")]
        public Habitat Habitat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pokemon is legendary.
        /// </summary>
        [JsonProperty(PropertyName = "is_legendary")]
        public bool IsLegendary { get; set; }

        /// <summary>
        /// Gets or sets the pokemon flavor text.
        /// </summary>
        [JsonProperty(PropertyName = "flavor_text_entries")]
        public List<Description> Description { get; set; }
    }
}
