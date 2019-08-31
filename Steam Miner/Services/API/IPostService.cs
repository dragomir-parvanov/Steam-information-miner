namespace Steam_Miner.Services.API
{
    using System.Collections.Generic;
    using Steam_Miner.Models;

    /// <summary>
    /// All HTTP POST methods.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Sends the profiles to the API.
        /// </summary>
        /// <param name="profiles">The scanned profiles that needs to be send.</param>
        void SendProfiles(List<ScannedProfile> profiles);

        /// <summary>
        /// Sends the items to the API.
        /// </summary>
        /// <param name="items">The items that needs to be send.</param>
        void SendItems(List<Item> items);
    }
}
