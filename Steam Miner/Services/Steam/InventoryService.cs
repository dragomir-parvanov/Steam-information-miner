namespace Steam_Miner.Services.Steam
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    using Steam_Miner.Models;
    using Steam_Miner.Services.API;

    /// <inheritdoc/>
    public class InventoryService : IInventoryService
    {
        /// <inheritdoc/>
        public List<Item> GetPlayerInventory(string steamID64, string gameAppID)
        {
            var httpRequest = new HTTPRequesterService();

            var url = $"https://steamcommunity.com/inventory/{steamID64}/{gameAppID}/2?l=english&count=1000";

            var response = string.Empty;
            try
            {
                response = httpRequest.Get(url, 20, 600);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("403"))
                {
                    throw new Exception("inventory is private");
                }
                else
                {
                    // cannot retrieve any items
                    return new List<Item>();
                }
            }

            JObject json = JObject.Parse(response);

            List<ClassID> classIDs = new List<ClassID>();

            List<Item> items = new List<Item>();

            foreach (var item in json.SelectToken("assets"))
            {
                classIDs.Add(new ClassID
                {
                    ClassId = item.SelectToken("classid").ToString(),
                    Count = 1,
                });
            }

            List<ItemID> identificationList = new List<ItemID>();

            foreach (var item in json.SelectToken("descriptions"))
            {
                identificationList.Add(new ItemID
                {
                    MarketName = item.SelectToken("market_hash_name").ToString(),
                    ClassID = item.SelectToken("classid").ToString(),
                });
            }

            // clearing classIDs of class ID duplicates
            for (int i = 0; i < classIDs.Count; i++)
            {
                for (int j = i + 1; j < classIDs.Count; j++)
                {
                    if (classIDs[i].ClassId == classIDs[j].ClassId)
                    {
                        classIDs[i].Count++;
                        classIDs.RemoveAt(j--);
                    }
                }
            }

            // clearing identificationList of class ID duplicates
            for (int i = 0; i < identificationList.Count; i++)
            {
                for (int j = i + 1; j < identificationList.Count; j++)
                {
                    if (identificationList[i].ClassID == identificationList[j].ClassID)
                    {
                        identificationList.RemoveAt(j--);
                    }
                }
            }

            // identifying items
            for (int i = 0; i < classIDs.Count; i++)
            {
                for (int j = 0; j < identificationList.Count; j++)
                {
                    if (classIDs[i].ClassId == identificationList[j].ClassID)
                    {
                        items.Add(new Item
                        {
                            Id = identificationList[j].MarketName,
                            Count = classIDs[i].Count,
                        });
                    }
                }
            }

            // combining the items with the same market hash name, but different classID
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (items[i].Id == items[j].Id)
                    {
                        items[i].Count += items[j].Count;
                        items.RemoveAt(j--);
                    }
                }
            }

            return items;
        }
    }
}
