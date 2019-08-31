namespace Steam_Miner.Services.Steam.Parsers
{
    using System;
    using System.Xml;
    using SteamTradeBot.Models.Enums;

    /// <summary>
    /// Gets the privacy status of a profile.
    /// </summary>
    public interface IParseService
    {
        /// <summary>
        /// Gets the privacy status of a steam profile.
        /// </summary>
        /// <param name="innerText">The value from xml element.</param>
        /// <returns>privacy status.</returns>
        PrivacyStatus GetPrivacyStatus(string innerText);

        /// <summary>
        /// Determines whether is account limited by the text.
        /// </summary>
        /// <param name="innerText">The inner text of the XML.</param>
        /// <returns>
        ///   If account is limited, return true.
        /// </returns>
        bool GetIfAccountIsLimited(string innerText);

        /// <summary>
        /// Parse the string, so it returns how many days the account have been offline.
        /// </summary>
        /// <param name="innerText">The inner text of the XML.</param>
        /// <returns>days since the account is offline.</returns>
        int GetOfflineSinceDays(string innerText);

        /// <summary>
        /// Parse the steam XML date format to system dateTime.
        /// </summary>
        /// <param name="innerText">The inner text of the XML.</param>
        /// <returns>Date when the account was created.</returns>
        DateTime GetMemberSince(string innerText);

        /// <summary>
        /// Checks for csgo in games.
        /// </summary>
        /// <param name="gameNodes">The xml node.</param>
        /// <returns>If he owns csgo, return true.</returns>
        bool CheckForCSGO(XmlNode gameNodes);

        /// <summary>
        /// Gets the country without city and etc...
        /// </summary>
        /// <param name="innerText">The inner text of the XML.</param>
        /// <returns>Country.</returns>
        string GetCountry(string innerText);
    }
}
