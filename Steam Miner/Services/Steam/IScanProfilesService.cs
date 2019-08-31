namespace Steam_Miner.Services.Steam
{
    using System.Collections.Generic;
    using Steam_Miner.Models;

    /// <summary>
    /// Scanning the the profiles from Steam.
    /// </summary>
    public interface IScanProfilesService
    {
        /// <summary>
        /// Scans the profiles.
        /// </summary>
        /// <param name="profiles">The profiles.</param>
        /// <returns>scanned profiles.</returns>
        List<ScannedProfile> ScanProfiles(List<ToBeScannedProfile> profiles);
    }
}
