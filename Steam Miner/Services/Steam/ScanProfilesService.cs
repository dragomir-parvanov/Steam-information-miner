namespace Steam_Miner.Services.Steam
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Xml;
    using Steam_Miner.Models;
    using SteamTradeBot.Models.Enums;

    /// <inheritdoc/>
    public class ScanProfilesService : IScanProfilesService
    {
        /// <inheritdoc/>
        public List<ScannedProfile> ScanProfiles(List<ToBeScannedProfile> profiles)
        {
            List<ScannedProfile> scannedProfiles = new List<ScannedProfile>();
            var httpRequest = new API.HTTPRequesterService();
            var parser = new Parsers.ParseService();
            XmlDocument xml = new XmlDocument();

            foreach (var profile in profiles)
            {
                var url = $"https://steamcommunity.com/profiles/{profile.SteamID64}?xml=1";

                var response = string.Empty;

                try
                {
                    response = httpRequest.Get(url, 20, 600);
                }
                catch
                {
                    continue;
                }

                // That means the profile is not found.
                if (response[1] == '!')
                {
                    continue;
                }

                xml.LoadXml(response);
                var profileTest = xml.GetElementsByTagName("profile");
                var node = profileTest[0];
                var scannedProfile = new ScannedProfile
                {
                    SteamID64 = node.SelectSingleNode("steamID64").InnerText,

                    Name = node.SelectSingleNode("steamID").InnerText,

                    PrivacyStatus = parser.GetPrivacyStatus(node.SelectSingleNode("privacyState").InnerText),

                    IsAccountLimited = parser.GetIfAccountIsLimited(node.SelectSingleNode("isLimitedAccount").InnerText),
                };

                // if the account is not public, we cannot retrieve this information.
                if (scannedProfile.PrivacyStatus == PrivacyStatus.Public)
                {
                    scannedProfile.AccountCreated = DateTime.Parse(node.SelectSingleNode("memberSince").InnerText);
                    scannedProfile.OfflineSinceDays = parser.GetOfflineSinceDays(node.SelectSingleNode("stateMessage").InnerText);
                    scannedProfile.Country = parser.GetCountry(node.SelectSingleNode("location").InnerText);

                    if (profile.FromCsgoGroup == false)
                    {
                        scannedProfile.HasCsgo = parser.CheckForCSGO(node.SelectSingleNode("mostPlayedGames"));
                    }
                    else
                    {
                        scannedProfile.HasCsgo = true;
                    }

                    var items = new List<Item>();

                    try
                    {
                        items = new Steam.InventoryService().GetPlayerInventory(profile.SteamID64, "730");
                    }
                    catch (Exception e)
                    {
                        if (e.Message == "inventory is private")
                        {
                            scannedProfile.IsInventoryPrivate = true;
                        }
                    }

                    if (items.Count > 0)
                    {
                        scannedProfile.HasCsgo = true;
                        scannedProfile.Items = items;
                    }
                }
                else
                {
                    scannedProfile.IsInventoryPrivate = false;
                }

                scannedProfiles.Add(scannedProfile);
            }

            return scannedProfiles;
        }
    }
}
