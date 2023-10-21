using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WorldCupDL.Models;

namespace WorldCupDL.Repositories
{
    public interface ISetup
    {
        void SaveSettings(string championship, string language);
        bool CheckLanguage();
        bool CheckChampionship();
        string SetFavouriteTeam(string championship);
        void SaveFavouritePlayers(IDictionary<string, bool> FavouritePlayers);
        IDictionary<string, bool> GetFavouritePlayers(IDictionary<string, bool> FavouritePlayers);
        void SaveFavouriteTeam(string team);
        void CheckFavouritePlayer(Player player);
    }
}
