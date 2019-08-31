namespace Steam_Miner.Services.Steam
{
    using System.Collections.Generic;
    using Steam_Miner.Models;

    /// <summary>
    /// Collects information about inventories.
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Gets the player inventory.
        /// OLD METHOD.
        /// </summary>
        /// <param name="steamID64">The steamID64 of the profile.</param>
        /// <param name="gameAppID">The game application identifier.</param>
        /// <returns>List of items.</returns>
        List<Item> GetPlayerInventory(string steamID64, string gameAppID);
    }
}
