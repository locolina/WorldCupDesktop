using System;
using System.Collections.Generic;

namespace WorldCupDL.Constants
{
    public static class LocalStorageConst
    {
        private const string ProjectDirectory = "C:\\Users\\colin\\Documents\\Vaks\\dotnet praktikum\\LovroColinaProjekt\\WorldCupDesktopApp\\WorldCupDesktop\\WorldCupDL\\Resources\\";

        public static string PlayerData = $"{ProjectDirectory}PlayerData\\";
        public static string Settings = $"{ProjectDirectory}Settings.json";
        public static string FavouritePlayers_WF = $"{ProjectDirectory}FavoritePlayers.json";
        public static string FavouriteTeam = $"{ProjectDirectory}";
        public static string PlayerImage = $"{ProjectDirectory}FootballPlayer.png";
    }
}
