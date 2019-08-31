namespace Steam_Miner.Models
{
    using System;
    using System.Collections.Generic;
    using Steam_Miner.Models;
    using SteamTradeBot.Models.Enums;

    /// <summary>
    /// Scanned profile with all his attributes.
    /// </summary>
    public class ScannedProfile
    {
        /// <summary>
        /// Gets or sets the steam ID64 of a steam profile..
        /// </summary>
        /// <value>
        /// The steam ID- its always 17 digits.
        /// </value>
        public string SteamID64 { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The Steam name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this profile instance account is limited.
        /// </summary>
        /// <value><c>true</c> if this instance is account limited; otherwise, <c>false</c>.</value>
        public bool IsAccountLimited { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this profile instance inventory is private.
        /// </summary>
        /// <value><c>true</c> if this instance is inventory private; otherwise, <c>false</c>.</value>
        public bool IsInventoryPrivate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this profile instance has csgo.
        /// </summary>
        /// <value><c>true</c> if this instance has csgo; otherwise, <c>false</c>.</value>
        public bool HasCsgo { get; set; }

        /// <summary>
        /// Gets or sets the privacy status. <see cref="PrivacyStatus"/>.
        /// </summary>
        /// <value>The privacy status.</value>
        public PrivacyStatus PrivacyStatus { get; set; }

        /// <summary>
        /// Gets or sets the account created date.
        /// </summary>
        /// <value>The account created date.</value>
        public DateTime AccountCreated { get; set; }

        /// <summary>
        /// Gets or sets the added on date.
        /// </summary>
        /// <value>The added on date.</value>
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// Gets or sets the items in a profile.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets the last time online of a steam profie.
        /// </summary>
        /// <value>
        /// The last time online.
        /// </value>
        public int OfflineSinceDays { get; set; }
    }
}
