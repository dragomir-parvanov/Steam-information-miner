namespace Steam_Miner.Services.API
{
    using System;

    /// <inheritdoc/>
    public class APIConfigService : IAPIConfigService
    {
        /// <inheritdoc/>
        public string Key()
        {
            try
            {
                return System.IO.File.ReadAllText("config\\web_host.cfg");
            }
            catch
            {
                throw new Exception("Config file is missing");
            }
        }

        /// <inheritdoc/>
        public string Url()
        {
            try
            {
                return System.IO.File.ReadAllText("config\\web_host.cfg");
            }
            catch
            {
                throw new Exception("Config file is missing");
            }
        }
    }
}
