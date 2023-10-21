using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldCupDL.Constants;
using WorldCupDL.Models;

namespace WorldCupWPF.UC
{
    /// <summary>
    /// Interaction logic for PlayerUC.xaml
    /// </summary>
    public partial class PlayerUC : UserControl
    {
        private string imagesFolderPath = $"{LocalStorageConst.PlayerImage}";
        internal Player PlayersUC { get; set; }
        internal Match SelectedMatch { get; set; }

        internal int GoalsScored { get; set; }
        internal int YellowCards { get; set; }
        public PlayerUC(Player playersUC, Match match)
        {
            InitializeComponent();
            PlayersUC = playersUC;
            SelectedMatch = match;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetGoalsAndYellows();
            lblNumber.Content = PlayersUC.ShirtNumber;
            lblPlayerName.Content = PlayersUC.Name;
            string imagePath = $"{LocalStorageConst.PlayerData}{PlayersUC.Name}.jpg";
            try
            {
                if (File.Exists(imagePath))
                {
                    imgPlayer.Source = new BitmapImage(new Uri(imagePath));
                }
                else
                    imgPlayer.Source = new BitmapImage(new Uri(LocalStorageConst.PlayerImage));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                // CustomEx.ShowMessage(Resources.Messages.fileException);
                // return;
            }
        }

        private void SetGoalsAndYellows()
        {
            var events = SelectedMatch.HomeTeamEvents.Concat(SelectedMatch.AwayTeamEvents);
            foreach (var e in events)
            {
                if (e.TypeOfEvent == WorldCupDL.Models.Enums.TypeOfEvent.Goal && e.Player.ToLower() == PlayersUC.Name.ToLower())
                {
                    GoalsScored++;
                }

                if (e.TypeOfEvent == WorldCupDL.Models.Enums.TypeOfEvent.YellowCard && e.Player.ToLower() == PlayersUC.Name.ToLower())
                {
                    YellowCards++;
                }
            }
        }

        private void PlayerUC_Click(object sender, MouseButtonEventArgs e)
        {
            Window playerInfo = new PlayerStats(this);
            playerInfo.ShowDialog();
        }
    }
}
