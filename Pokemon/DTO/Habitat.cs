namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Habitat object.
    /// </summary>
    public class Habitat
    {
        /// <summary>
        /// Gets or sets the pokemon habitat name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
