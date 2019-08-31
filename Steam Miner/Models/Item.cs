namespace Steam_Miner.Models
{
    /// <summary>
    /// Represents model steam item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the count of the item.
        /// </summary>
        public int Count { get; set; }
    }
}