namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Translation response contents object.
    /// </summary>
    public class TranslationResponseContents
    {
        /// <summary>
        /// Gets or sets the translated text.
        /// </summary>
        [JsonProperty(PropertyName = "translated")]
        public string Translated { get; set; }
    }
}
