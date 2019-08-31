namespace Steam_Miner
{
    using System;
    using System.Collections.Generic;
    using Steam_Miner.Models;
    using Steam_Miner.Services.Steam;
    using Steam_Miner.Services.Steam.Parsers;

    /// <summary>
    /// Startup class.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            var scanService = new ScanProfilesService();

            var itemScanService = new ItemPriceService();
            var testList = new List<ToBeScannedProfile>
            {
                new ToBeScannedProfile
                {
                    SteamID64 = "76561198078708271",
                    FromCsgoGroup = false,
                },
                new ToBeScannedProfile
                {
                    SteamID64 = "76561198258754792",
                    FromCsgoGroup = false,
                },
                new ToBeScannedProfile
                {
                    SteamID64 = "76561198949266425",
                    FromCsgoGroup = false,
                },
                new ToBeScannedProfile
                {
                    SteamID64 = "76561198898761186",
                    FromCsgoGroup = false,
                },
                new ToBeScannedProfile
                {
                    SteamID64 = "76561198317520074",
                    FromCsgoGroup = false,
                },
                new ToBeScannedProfile
                {
                    SteamID64 = "76561197992217121",
                    FromCsgoGroup = false,
                },
                new ToBeScannedProfile
                {
                    SteamID64 = "76561198016347652",
                    FromCsgoGroup = false,
                },
            };

            var testListItems = new List<string>();

            var test = scanService.ScanProfiles(testList);

            Console.WriteLine("finished");
        }
    }
}
