namespace Pokemon.Helpers
{
    using Newtonsoft.Json;
    using Pokemon.DTO;
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// Helper class for building requests.
    /// </summary>
    public class RequestBuilder : IRequestBuilder
    {
        /// <inheritdoc/>
        public HttpContent BuildTranslationRequest(string description)
        {
            TranslationRequest translationRequest = new()
            {
                Text = description
            };

            return new StringContent(JsonConvert.SerializeObject(translationRequest), Encoding.UTF8, "application/json");
        }
    }
}
