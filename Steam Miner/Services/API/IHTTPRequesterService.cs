namespace Steam_Miner.Services.API
{
    /// <summary>
    /// All HTTP request methods.
    /// </summary>
    public interface IHTTPRequesterService
    {
        /// <summary>
        /// Get request method.
        /// </summary>
        /// <param name="url">The URL that the request will be send to.</param>
        /// <param name="maxTries">The max tries that the method will try to connect to the server, before giving up.</param>
        /// <param name="secondsBeforeReTrying">The seconds after.</param>
        /// <returns>JSON.</returns>
        string Get(string url, int maxTries = 1, int secondsBeforeReTrying = 0);

        /// <summary>
        /// Post request method.
        /// </summary>
        /// <param name="url">The URL that the request will be send to.</param>
        /// <param name="headers">The headers that we send in the POST request.</param>
        /// <returns>Success response.</returns>
        string Post(string url, string headers);
    }
}
