namespace Steam_Miner.Services.API
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Api configuration.
    /// </summary>
    public interface IAPIConfigService
    {
        /// <summary>
        /// Gets the api key for the remote server.
        /// </summary>
        /// <returns>api key.</returns>
        string Key();

        /// <summary>
        /// Gets the web Url for the remote server.
        /// </summary>
        /// <returns>remote server uri.</returns>
        string Url();
    }
}
