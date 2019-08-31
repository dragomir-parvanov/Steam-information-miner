namespace Steam_Miner.Services.API
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Newtonsoft.Json;
    using Steam_Miner.Models;

    /// <inheritdoc/>
    public class PostService : IPostService
    {
        /// <inheritdoc/>
        public void SendProfiles(List<ScannedProfile> profiles)
        {
            var apiConfig = new APIConfigService();
            var httpRequest = new HTTPRequesterService();

            var url = apiConfig.Url() + "/get/items&key=" + apiConfig.Key();

            string headers = JsonConvert.SerializeObject(profiles);

            httpRequest.Post(url, headers);
        }

        /// <inheritdoc/>
        public void SendItems(List<Item> items)
        {
            var apiConfig = new APIConfigService();
            var httpRequest = new HTTPRequesterService();

            var url = apiConfig.Url() + "/get/items&key=" + apiConfig.Key();

            string headers = JsonConvert.SerializeObject(items);

            httpRequest.Post(url, headers);
            }
        }
    }
