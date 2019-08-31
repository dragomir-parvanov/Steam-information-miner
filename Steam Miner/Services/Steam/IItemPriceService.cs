namespace Steam_Miner.Services.Steam
{
    using System.Collections.Generic;
    using Steam_Miner.Models;

    /// <summary>
    /// Collecting steam prices from steam community market.
    /// </summary>
    public interface IItemPriceService
    {
        /// <summary>
        /// Gets the item prices.
        /// </summary>
        /// <param name="itemsUrls">The items.</param>
        /// <returns>List of item with prices.</returns>
        List<ItemPrice> GetItemPrices(List<string> itemsUrls);
    }
}
