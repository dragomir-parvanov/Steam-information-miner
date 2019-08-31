namespace Steam_Miner.Models
{
    /// <summary>
    /// model for getting steam item prices from steam market.
    /// </summary>
    public class ItemPrice
    {
        /// <summary>
        /// Gets or sets the market hash name of the item.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The quantily sold of the item for 24 hours at the community market.</value>
        public int Volume { get; set; }

        /// <summary>
        /// Gets or sets the lowest price.
        /// </summary>
        /// <value>The lowest price for the item at the moment at the community market.</value>
        public decimal LowestPrice { get; set; }

        /// <summary>
        /// Gets or sets the average price.
        /// </summary>
        /// <value>The average price (24 hours record).</value>
        public decimal AveragePrice { get; set; }

        /// <summary>
        /// Gets or sets the sell price.
        /// </summary>
        /// <value>The price that this item can be sold.</value>
        public decimal SellPrice { get; set; }
    }
}
