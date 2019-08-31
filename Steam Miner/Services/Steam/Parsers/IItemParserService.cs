namespace Steam_Miner.Services.Steam.Parsers
{
    /// <summary>
    /// Parses string, so they can be parsed later to int, double etc...
    /// </summary>
    public interface IItemParserService
    {
        /// <summary>
        /// Correcting the output of a item prices.
        /// </summary>
        /// <example>if its "2,3$", make it "2.3".</example>
        /// <param name="output">The output.</param>
        /// <returns>Corrected output.</returns>
        decimal PriceParse(string output);

        /// <summary>
        /// Parses the volume of a steam item..
        /// </summary>
        /// <example>If its "1399,39" parse it to "139939".</example>
        /// <param name="ouput">The json ouput.</param>
        /// <returns>integer.</returns>
        int VolumeParse(string ouput);
    }
}
