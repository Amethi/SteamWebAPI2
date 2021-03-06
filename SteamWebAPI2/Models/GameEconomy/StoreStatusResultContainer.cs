﻿using Newtonsoft.Json;

namespace SteamWebAPI2.Models.GameEconomy
{
    internal class StoreStatusResult
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("store_status")]
        public int StoreStatus { get; set; }
    }

    internal class StoreStatusResultContainer
    {
        [JsonProperty("result")]
        public StoreStatusResult Result { get; set; }
    }
}