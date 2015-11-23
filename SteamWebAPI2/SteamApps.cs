﻿using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamApps : SteamWebInterface
    {
        public SteamApps(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamApps")
        {
        }

        public async Task<IReadOnlyCollection<SteamApp>> GetAppListAsync()
        {
            var steamAppList = await CallMethodAsync<SteamAppListResultContainer>("GetAppList", 2);
            return new ReadOnlyCollection<SteamApp>(steamAppList.AppListResult.Apps);
        }

        public async Task<SteamAppUpToDateCheckResult> UpToDateCheckAsync(int appId, int version)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("version", version, parameters);

            var upToDateCheckResult = await CallMethodAsync<SteamAppUpToDateCheckResultContainer>("UpToDateCheck", 1, parameters);
            return upToDateCheckResult.Result;
        }
    }
}
