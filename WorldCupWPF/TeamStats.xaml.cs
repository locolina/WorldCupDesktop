using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using WorldCupDL.Models;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for TeamStats.xaml
    /// </summary>
    public partial class TeamStats : Window
    {
        public TeamResultsAPI teamResultsAPI;

        public TeamStats(TeamResultsAPI team)
        {
            InitializeComponent();
            teamResultsAPI = team;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            name.Content = teamResultsAPI.Country;
            code.Content = teamResultsAPI.FifaCode;
            played.Content = teamResultsAPI.GamesPlayed;
            wins.Content = teamResultsAPI.Wins;
            losses.Content = teamResultsAPI.Losses;
            draws.Content = teamResultsAPI.Draws;
            scored.Content = teamResultsAPI.GoalsFor;
            conceded.Content = teamResultsAPI.GoalsAgainst;
            diff.Content = teamResultsAPI.GoalDifferential;
        }
    }
}
