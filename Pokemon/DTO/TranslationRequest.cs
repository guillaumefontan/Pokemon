namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Translation request object.
    /// </summary>
    public class TranslationRequest
    {
        /// <summary>
        /// Gets or sets the translation text.
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
