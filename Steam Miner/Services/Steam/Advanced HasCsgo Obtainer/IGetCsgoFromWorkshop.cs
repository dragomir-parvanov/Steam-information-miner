namespace Steam_Miner.Services.Steam.Advanced_HasCsgo_Obtainer
{
    /// <summary>
    /// Gets if a profile have something related to csgo in steam workshop.
    /// </summary>
    public interface IGetCsgoFromWorkshop
    {
        /// <summary>
        /// Gets if a profile have screenshoot from CSGO.
        /// </summary>
        /// <param name="steamID64">The steam ID64.</param>
        /// <returns>If he have csgo related screenshoot, return true, otherwise false.</returns>
        bool FromScreenShots(string steamID64);

        /// <summary>
        /// Gets if a profile have any csgo related workshop item.
        /// </summary>
        /// <param name="steamID64">The steam ID64.</param>
        /// <returns>If he have csgo related workshop item, return true, otherwise false.</returns>
        bool FromWorkShopItems(string steamID64);
    }
}
