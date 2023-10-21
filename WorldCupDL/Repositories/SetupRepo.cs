using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using WorldCupDL.Constants;
using WorldCupDL.Models;

namespace WorldCupDL.Repositories
{
    public class SetupRepo : ISetup
    {
        public bool CheckChampionship()
        {
            if (File.Exists(LocalStorageConst.Settings))
            {
                string json = File.ReadAllText(LocalStorageConst.Settings);
                Dictionary<string, string> settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                return settings.ContainsKey("Championship") && settings["Championship"] == "Men";
            }
            return false;
        }

        public bool CheckLanguage()
        {
            if (File.Exists(LocalStorageConst.Settings))
            {
                string json = File.ReadAllText(LocalStorageConst.Settings);
                Dictionary<string, string> settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (settings != null && settings.TryGetValue("Language", out string language))
                {
                    return language == "HRV";
                }
            }
            return false;
        }

        public void SaveSettings(string championship, string language)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                { "Language", language },
                { "Championship", championship }
            };

            string json = JsonConvert.SerializeObject(keyValuePairs);
            File.WriteAllText(LocalStorageConst.Settings, json);
        }

        public string SetFavouriteTeam(string championship)
        {
            var fileName = $"{LocalStorageConst.FavouriteTeam}FavouriteTeam.json";
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                Dictionary<string, string> teamData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (teamData.TryGetValue("Team", out string team))
                {
                    return team;
                }
            }
            return string.Empty;
        }

        public void SaveFavouritePlayers(IDictionary<string, bool> favouritePlayers)
        {
            string json = JsonConvert.SerializeObject(favouritePlayers);
            File.WriteAllText(LocalStorageConst.FavouritePlayers_WF, json);
        }

        public IDictionary<string, bool> GetFavouritePlayers(IDictionary<string, bool> FavouritePlayers)
        {
            var fileName = LocalStorageConst.FavouritePlayers_WF;
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
            }
            return new Dictionary<string, bool>();
        }

        public void SaveFavouriteTeam(string team)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
            {
                { "Team", team }
            };

            string json = JsonConvert.SerializeObject(keyValuePairs);
            File.WriteAllText($"{LocalStorageConst.FavouriteTeam}FavouriteTeam.json", json);
        }

        public void CheckFavouritePlayer(Player player)
        {
            var fileName = LocalStorageConst.FavouritePlayers_WF;
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                Dictionary<string, bool> playerData = JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
                if (playerData.TryGetValue(player.Name, out bool isFavorite))
                {
                    player.Favourite = isFavorite;
                }
            }
        }
    }
}
