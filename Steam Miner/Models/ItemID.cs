namespace Steam_Miner.Models
{
    /// <summary>
    /// Used for identifying steam items by their description.
    /// </summary>
    public class ItemID
    {
        /// <summary>
        /// Gets or sets the market hash name of the item.
        /// </summary>
        /// <value>
        /// The market hash name.
        /// </value>
        public string MarketName { get; set; }

        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>
        /// The class identifier.
        /// </value>
        public string ClassID { get; set; }
    }
}
