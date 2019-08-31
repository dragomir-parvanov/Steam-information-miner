namespace Steam_Miner.Services.Steam
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Newtonsoft.Json.Linq;
    using Steam_Miner.Models;
    using Steam_Miner.Services.API;
    using Steam_Miner.Services.Steam.Parsers;

    /// <inheritdoc/>
    public class ItemPriceService : IItemPriceService
    {
        /// <inheritdoc/>
        public List<ItemPrice> GetItemPrices(List<string> itemsUrls)
        {
            var items = new List<ItemPrice>();

            var httpRequest = new HTTPRequesterService();

            var itemParser = new ItemParserService();

            // var testUrl = "http://steamcommunity.com/market/priceoverview/?appid=730&currency=3&market_hash_name=StatTrak%E2%84%A2 M4A1-S | Hyper Beast (Minimal Wear)";
            foreach (var itemUrl in itemsUrls)
            {
                var response = string.Empty;

                try
                {
                    response = httpRequest.Get(itemUrl, 20, 600);
                }
                catch
                {
                    continue;
                }

                var json = JObject.Parse(response);
                var item = new ItemPrice
                {
                    Volume = itemParser.VolumeParse((string)json.SelectToken("volume")),
                    LowestPrice = itemParser.PriceParse((string)json.SelectToken("lowest_price")),
                    AveragePrice = itemParser.PriceParse((string)json.SelectToken("median_price")),
                };
                items.Add(item);
            }

            return items;
        }
    }
}
