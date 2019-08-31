namespace Steam_Miner.Services.Steam.Advanced_HasCsgo_Obtainer
{
    /// <inheritdoc/>
    public class GetCsgoFromGroups : IGetCsgoFromGroups
    {
        /// <inheritdoc/>
        public bool GetCsgo(string steamID64)
        {
            var httpRequest = new API.HTTPRequesterService();
            var response = string.Empty;
            var url = $"https://steamcommunity.com/profiles/{steamID64}/groups";

            try
            {
                response = httpRequest.Get(url, 20, 600).ToLower();
            }
            catch
            {
                // cannot retrieve from this method
                return false;
            }

            if (response.Contains("csgo") || response.Contains("cs:go") || response.Contains("counter-strike") || response.Contains("counter strike"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
