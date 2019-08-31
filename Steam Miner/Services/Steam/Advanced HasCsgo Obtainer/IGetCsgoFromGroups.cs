namespace Steam_Miner.Services.Steam.Advanced_HasCsgo_Obtainer
{
    /// <summary>
    /// Gets if the player is in any csgo group.
    /// </summary>
    public interface IGetCsgoFromGroups
    {
        /// <summary>
        /// Gets the csgo.
        /// </summary>
        /// <param name="steamID64">The steam i D64.</param>
        /// <returns>If he is any csgo related group, return true.</returns>
        bool GetCsgo(string steamID64);
    }
}
