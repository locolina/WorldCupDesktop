using System;
using System.Collections.Generic;
using WorldCupDL.Models;
using WorldCupDL.Repositories;

namespace WorldCupDL.Managers
{
    public class SettingsManager
    {
        private readonly ISetup repo;

        public SettingsManager()
        {
            repo = RepoFactory.GetResourcesRepository();
        }

        public bool CheckForChampionshipType()
        {
            return repo.CheckChampionship();
        }

        public bool CheckForLanguage()
        {
            return repo.CheckLanguage();
        }

        public void SaveSettings(string championship, string language)
        {
            repo.SaveSettings(championship, language);
        }

        public string SetFavouriteTeam(string championship)
        {
            return repo.SetFavouriteTeam(championship);
        }

        public void SaveFavoritePlayers(IDictionary<string, bool> favoritePlayers)
        {
            repo.SaveFavouritePlayers(favoritePlayers);
        }

        public IDictionary<string, bool> FillFavoritePlayers(IDictionary<string, bool> favoritePlayers)
        {
            return repo.GetFavouritePlayers(favoritePlayers);
        }

        public void SaveFavoriteTeam(string team)
        {
            repo.SaveFavouriteTeam(team);
        }

        public void CheckFavoritePlayer(Player player)
        {
            repo.CheckFavouritePlayer(player);
        }
    }
}
