namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    public class DescriptionLanguage
    {
        /// <summary>
        /// Gets or sets the flavor text language.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Language { get; set; }
    }
}
