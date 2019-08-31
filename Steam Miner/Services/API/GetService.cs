namespace Steam_Miner.Services.API
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Newtonsoft.Json;
    using Steam_Miner.Models;

    /// <inheritdoc/>
    public class GetService : IGetService
    {
        /// <inheritdoc/>
        public List<string> Items()
        {
            var apiConfig = new APIConfigService();
            var httpRequest = new HTTPRequesterService();

            var url = apiConfig.Url() + "/get/items&key=" + apiConfig.Key();

            string response;
            while (true)
            {
                try
                {
                    response = httpRequest.Get(url);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(10000);
                }
            }

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        /// <inheritdoc/>
        public List<ToBeScannedProfile> Profiles()
        {
            var apiConfig = new APIConfigService();
            var httpRequest = new HTTPRequesterService();
            var url = apiConfig.Url() + "/get/profiles&key=" + apiConfig.Key();

            string response;
            while (true)
            {
                try
                {
                    response = httpRequest.Get(url);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(60000);
                }
            }

            return JsonConvert.DeserializeObject<List<ToBeScannedProfile>>(response);
        }
    }
}
