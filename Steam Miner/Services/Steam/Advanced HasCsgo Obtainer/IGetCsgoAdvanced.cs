namespace Steam_Miner.Services.Steam.Advanced_HasCsgo_Obtainer
{
    /// <summary>
    /// Gets if the user owns csgo trought other sources.
    /// Like workshops, csgo groups and screenshoots.
    /// </summary>
    public interface IGetCsgoAdvanced
    {
        /// <summary>
        /// Gets if the user owns csgo.
        /// </summary>
        /// <returns>if he owns CSGO, return true.</returns>
        /// <param name="steamID64">The steam id that will be scanned for csgo.</param>
        bool GetCsgo(string steamID64);
    }
}
