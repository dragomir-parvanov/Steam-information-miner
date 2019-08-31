namespace Steam_Miner.Services.API
{
    using System;
    using System.Collections.Generic;
    using Steam_Miner.Models;

    /// <summary>
    /// All HTTP GET methods.
    /// </summary>
    public interface IGetService
    {
        /// <summary>
        /// Gets the profiles that needs to be scanned from API.
        /// </summary>
        /// <returns>List of profiles.</returns>
        List<ToBeScannedProfile> Profiles();

        /// <summary>
        /// Gets the items that needs to be scanned from API.
        /// </summary>
        /// <returns>List of items.</returns>
        List<string> Items();
    }
}
