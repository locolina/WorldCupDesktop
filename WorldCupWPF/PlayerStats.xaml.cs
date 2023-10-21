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
using System.Windows.Shapes;
using WorldCupDL.Constants;
using WorldCupWPF.UC;

namespace WorldCupWPF
{
    public partial class PlayerStats : Window
    {
        private PlayerUC PlayerUC { get; set; }
        private string imagesFolderPath = $"{LocalStorageConst.PlayerData}";

        public PlayerStats(UC.PlayerUC playerUC)
        {
            InitializeComponent();
            PlayerUC = playerUC;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string imagePath = $"{imagesFolderPath}{PlayerUC.PlayersUC.Name}.jpg";
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
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }

            lblName.Content = PlayerUC.PlayersUC.Name;
            lblNumber.Content = PlayerUC.PlayersUC.ShirtNumber;
            lblCaptain.Content = PlayerUC.PlayersUC.Captain ? "C" : "";
            lblPosition.Content = PlayerUC.PlayersUC.Position;
            lblGoalsScored.Content = PlayerUC.GoalsScored;
            lblYellowCards.Content = PlayerUC.YellowCards;
        }
    }
}
