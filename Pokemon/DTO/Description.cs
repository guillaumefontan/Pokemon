namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Floavor text object.
    /// </summary>
    public class Description
    {
        /// <summary>
        /// Gets or sets the flavor text.
        /// </summary>
        [JsonProperty(PropertyName = "flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// Gets or sets the flavor text language.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public DescriptionLanguage DescriptionLanguage { get; set; }
    }
}
