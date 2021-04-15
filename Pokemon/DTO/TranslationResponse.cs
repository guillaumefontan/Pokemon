namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Translation response object.
    /// </summary>
    public class TranslationResponse
    {
        /// <summary>
        /// Gets or sets the translation contents.
        /// </summary>
        [JsonProperty(PropertyName = "contents")]
        public TranslationResponseContents Contents { get; set; }

        /// <summary>
        /// Gets or sets the translation status.
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public TranslationResponseStatus Status { get; set; }
    }
}
