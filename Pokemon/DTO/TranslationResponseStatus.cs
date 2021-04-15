namespace Pokemon.DTO
{
    using Newtonsoft.Json;

    /// <summary>
    /// Translation request object.
    /// </summary>
    public class TranslationResponseStatus
    {
        /// <summary>
        /// Gets or sets the translation success total.
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}
