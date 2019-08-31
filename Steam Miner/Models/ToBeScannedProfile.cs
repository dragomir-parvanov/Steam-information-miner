namespace Steam_Miner.Models
{
    /// <summary>
    /// Profiles that are yet to be scanned.
    /// </summary>
    public class ToBeScannedProfile
    {
        /// <summary>
        /// Gets or sets the steam 64 ID of a profile.
        /// </summary>
        public string SteamID64 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the steamID64 is from a csgo group.
        /// </summary>
        public bool FromCsgoGroup { get; set; }
    }
}
