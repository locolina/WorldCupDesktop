using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using WorldCupDL.Managers;
using WorldCupDL.Models;
using WorldCupDL.Models.Enums;
using WorldCupWPF.UC;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly InitialSetupManager manager = new InitialSetupManager();
        private readonly SettingsManager settingsManager = new SettingsManager();

        private IList<TeamResultsAPI> teamsFromResults;
        private IList<WorldCupDL.Models.Match> matches;
        private WorldCupDL.Models.Match Match { get; set; }
        private PlayerUC playerUC;
        private TeamResultsAPI HomeTeam;
        private TeamResultsAPI AwayTeam;
        private string Championship => manager.Gender;
        private string oldChampionship;

        public MainWindow()
        {
            try
            {
                if (!File.Exists(LocalStorageConst.Settings))
                {
                    OpenSettingsWindow();
                }
            }
            catch (Exception ex)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }

            SetCulture();
            InitializeComponent();
        }

        private void SetCulture()
        {
            string language = settingsManager.CheckForLanguage() ? "HRV" : "ENG";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillDdl();
            oldChampionship = Championship;
        }

        private async void FillDdl()
        {
            ddlHome.Items.Clear();
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                });

                teamsFromResults = await manager.GetAll();
                teamsFromResults.ToList().ForEach(t => ddlHome.Items.Add(t.ToString()));

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Mouse.OverrideCursor = null;
                });
            }
            catch (Exception ex)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }

            string favTeam = settingsManager.SetFavouriteTeam(Championship);
            if (favTeam == string.Empty)
            {
                ddlHome.SelectedIndex = -1;
            }
            else
            {
                ddlHome.SelectedItem = favTeam;
            }
        }

        private async void FillOpponents()
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                });

                matches = await manager.GetAllMatches(HomeTeam.FifaCode);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Mouse.OverrideCursor = null;
                });

                foreach (var m in matches)
                {
                    if (m.HomeTeam.Code == HomeTeam.FifaCode)
                    {
                        ddlAway.Items.Add(m.AwayTeam.ToString());
                    }
                    else
                    {
                        ddlAway.Items.Add(m.HomeTeam.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if (!(ddlHome.SelectedIndex == -1))
            {
                TeamStats(HomeTeam);
            }
            else
            {
                MessageBox.Show("Team not selected");
            }
        }

        private void TeamStats(TeamResultsAPI homeTeam)
        {
            Window window = new TeamStats(HomeTeam);
            window.ShowDialog();
        }

        private void btnAway_Click(object sender, RoutedEventArgs e)
        {
            if (!(ddlAway.SelectedIndex == -1))
            {
                TeamStats(AwayTeam);
            }
            else
            {
                MessageBox.Show("Team not selected");
            }
        }

        private void ddlAway_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetTeam(ddlAway);
            SetResult();
            ClearFootballField();
            FillPitch();
            FillBench();
        }

        private void FillBench()
        {
            List<Player> benchHome = new List<Player>();
            List<Player> benchAway = new List<Player>();

            if (HomeTeam.FifaCode == Match.HomeTeam.Code)
            {
                benchHome = Match.HomeTeamStatistics.Substitutes.ToList();
                benchAway = Match.AwayTeamStatistics.Substitutes.ToList();
            }
            else
            {
                benchHome = Match.AwayTeamStatistics.Substitutes.ToList();
                benchAway = Match.HomeTeamStatistics.Substitutes.ToList();
            }

            foreach (var player in benchHome)
            {
                PlayerUC playerUC = new PlayerUC(player, Match);

                pnlReservesHome.Children.Add(playerUC);
            }

            foreach (var player in benchAway)
            {
                PlayerUC playerUC = new PlayerUC(player, Match);

                pnlReservesAway.Children.Add(playerUC);
            }
        }

            private void ddlHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ddlAway.Items.Clear();
            ClearFootballField();
            lblScore.Content = string.Empty;
            SetTeam(ddlHome);
            FillOpponents();
        }

        private void ClearFootballField()
        {
            foreach (var panel in footballPitch.Children.OfType<StackPanel>())
            {
                panel.Children.Clear();
            }
        }

        private void FillPitch()
        {
            List<Player> startingHome = new List<Player>();
            List<Player> startingAway = new List<Player>();

            if (HomeTeam.FifaCode == Match.HomeTeam.Code)
            {
                startingHome = Match.HomeTeamStatistics.StartingEleven.ToList();
                startingAway = Match.AwayTeamStatistics.StartingEleven.ToList();
            }
            else
            {
                startingHome = Match.AwayTeamStatistics.StartingEleven.ToList();
                startingAway = Match.HomeTeamStatistics.StartingEleven.ToList();
            }

            foreach (var player in startingHome)
            {
                PlayerUC playerUC = new PlayerUC(player, Match);

                switch (player.Position)
                {
                    case Position.Goalie:
                        pnlGoalieHome.Children.Add(playerUC);
                        break;
                    case Position.Defender:
                        pnlDefenceHome.Children.Add(playerUC);
                        break;
                    case Position.Midfield:
                        pnlMidfieldHome.Children.Add(playerUC);
                        break;
                    case Position.Forward:
                        pnlForwardHome.Children.Add(playerUC);
                        break;
                }
            }

            foreach (var player in startingAway)
            {
                PlayerUC playerUC = new PlayerUC(player, Match);

                switch (player.Position)
                {
                    case Position.Goalie:
                        pnlGoalieAway.Children.Add(playerUC);
                        break;
                    case Position.Defender:
                        pnlDefenceAway.Children.Add(playerUC);
                        break;
                    case Position.Midfield:
                        pnlMidfieldAway.Children.Add(playerUC);
                        break;
                    case Position.Forward:
                        pnlForwardAway.Children.Add(playerUC);
                        break;
                }
            }
        }

        private void SetResult()
        {
            foreach (var m in matches)
            {
                if (m.AwayTeam.Code == AwayTeam.FifaCode)
                {
                    lblScore.Content = $"{m.HomeTeam.Goals} : {m.AwayTeam.Goals}";
                    Match = m;
                }
                else if (m.HomeTeam.Code == AwayTeam.FifaCode)
                {
                    lblScore.Content = $"{m.AwayTeam.Goals} : {m.HomeTeam.Goals}";
                    Match = m;
                }
            }
        }

        private void SetTeam(ComboBox ddl)
        {
            try
            {
                string team = ddl.SelectedItem.ToString();
                string fifaCode = team.Substring(team.LastIndexOf('(') + 1, 3);

                foreach (var t in teamsFromResults)
                {
                    if (t.FifaCode == fifaCode)
                    {
                        if (ddl.Name == "ddlHome")
                        {
                            HomeTeam = t;
                        }
                        else
                        {
                            AwayTeam = t;
                        }
                    }
                }
            }
            catch (Exception)
            {
                ddlAway.Items.Clear();
            }
        }

        private void OpenSettingsWindow()
        {
            var settingsWindow = new Settings(this)
            {
                Topmost = true
            };
            settingsWindow.ShowDialog();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            settingsManager.SaveFavoriteTeam(ddlHome.SelectedItem.ToString());
            oldChampionship = Championship;
            OpenSettingsWindow();
        }

        private void AppClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {


            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.WindowState = this.WindowState;
            Properties.Settings.Default.Save();

            if (ddlHome.SelectedIndex == -1)
            {
                Application.Current.Shutdown();
            }
            else
            {
                settingsManager.SaveFavoriteTeam(ddlHome.SelectedItem.ToString());
            }
        }

    }
}
