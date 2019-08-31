namespace Steam_Miner.Services.Steam.Advanced_HasCsgo_Obtainer
{
    /// <inheritdoc/>
    public class GetCsgoAdvanced : IGetCsgoAdvanced
    {
        /// <inheritdoc/>
        public bool GetCsgo(string steamID64)
        {
            if (new GetCsgoFromGroups().GetCsgo(steamID64) == true)
            {
                return true;
            }

            return false;
        }
    }
}
