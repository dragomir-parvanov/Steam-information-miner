namespace Steam_Miner.Services.Steam.Parsers
{
    using System;
    using System.Xml;
    using SteamTradeBot.Models.Enums;

    /// <inheritdoc/>
    public class ParseService : IParseService
    {
        /// <inheritdoc/>
        public bool CheckForCSGO(XmlNode gameNodes)
        {
            if (gameNodes == null)
            {
                // cannot retrieve csgo from this method
                return false;
            }

            foreach (XmlNode game in gameNodes.SelectNodes("mostPlayedGame"))
            {
                if (game.FirstChild.InnerText == "Counter-Strike: Global Offensive")
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public string GetCountry(string innerText)
        {
            var index = innerText.LastIndexOf(",");
            if (index != -1)
            {
                return innerText.Substring(index);
            }
            else
            {
                return innerText;
            }
        }

        /// <inheritdoc/>
        public PrivacyStatus GetPrivacyStatus(string value)
        {
            if (value == "friendsonly")
            {
                return PrivacyStatus.FriendsOnly;
            }

            if (value == "public")
            {
                return PrivacyStatus.Public;
            }

            if (value == "private")
            {
                return PrivacyStatus.Private;
            }

            throw new Exception($"Cannot get privacy status, tried to parse: {value}");
        }

        /// <inheritdoc/>
        public bool GetIfAccountIsLimited(string innerText)
        {
            return innerText == "1" ? true : false;
        }

        /// <inheritdoc/>
        public DateTime GetMemberSince(string innerText)
        {
            // When the account is created this year, it doesnt specify the year in the XML File.
            // If it doesnt have "," in the innerText, that means the account is created this year.
            if (innerText.Contains(","))
            {
                return DateTime.Parse(innerText);
            }
            else
            {
                var date = DateTime.Parse(innerText);

                return new DateTime(DateTime.Today.Year, date.Month, date.Day);
            }
        }

        /// <inheritdoc/>
        public int GetOfflineSinceDays(string innerText)
        {
            var indexOfDay = innerText.IndexOf("day");

            if (indexOfDay != -1)
            {
                // +4 because "line" is lenght of 4.
                var indexOfLastOnline = innerText.IndexOf("line") + 4;
                return int.Parse(innerText.Substring(indexOfLastOnline, indexOfDay - indexOfLastOnline));
            }

            var indexOfHrs = innerText.IndexOf("hrs");
            if (indexOfHrs != -1)
            {
                int hours = int.Parse(innerText.Substring(indexOfHrs - 3, 3));
                if (hours < 24)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            // that means that the user have been offline for less than a hour.
            return 0;
        }
    }
}