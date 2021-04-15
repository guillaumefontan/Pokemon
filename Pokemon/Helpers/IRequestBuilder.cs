namespace Pokemon.Helpers
{
    using System.Net.Http;

    /// <summary>
    /// Interface for the <see cref="RequestBuilder"/> class.
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        /// Method to build translation requests.
        /// </summary>
        /// <param name="description">String to translate.</param>
        /// <returns>The HTTP request content.</returns>
        HttpContent BuildTranslationRequest(string description);
    }
}