using System.Globalization;
using WorldCupDL.Constants;
using WorldCupDL.Managers;
using WorldCupDL.Models;
using WorldCupWF.Interfaces;
using WorldCupWF.UC;

namespace WorldCupWF
{
    public partial class MainFormWF : Form, IDragable
    {
        private readonly SettingsManager settingsManager = new SettingsManager();
        private readonly InitialSetupManager manager = new InitialSetupManager();
        private PlayerUC playerUC;
        private ISet<Player> players;
        private IList<WorldCupDL.Models.Match> matches;
        private string SelectedTeam;
        private string Championship => manager.Gender;
        public IDictionary<string, bool> FavPlayers { get; set; } = new Dictionary<string, bool>();

        public MainFormWF()
        {
            SetCulture();
            InitializeComponent();
        }

        private void SetCulture()
        {
            string language = settingsManager.CheckForLanguage() ? "HRV" : "ENG";
            CultureInfo culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void btnSettings_Click(object sender, EventArgs e) => OpenSettings();

        private void OpenSettings()
        {
            SaveSelectedTeam();
            var settings = new Settings(this);
            settings.TopMost = true;
            settings.ShowDialog();
        }

        private void MainFormWF_Load(object sender, EventArgs e)
        {
            FillFavoritePlayers();
            try
            {
                if (!File.Exists(LocalStorageConst.Settings))
                {
                    OpenSettings();
                }
                else
                {
                    SetForm();
                }
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        public void SetForm()
        {
            SetCulture();
            this.Controls.Clear();
            InitializeComponent();
            FillDdl();
        }

        private async void FillDdl()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var teams = await manager.GetAll();
                teams.ToList().ForEach(t => ddlPickTeam.Items.Add(t));
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }

            SelectedTeam = settingsManager.SetFavouriteTeam(Championship);
            if (SelectedTeam == string.Empty)
            {
                ddlPickTeam.SelectedIndex = -1;
            }
            else
                ddlPickTeam.SelectedIndex = ddlPickTeam.FindStringExact(SelectedTeam);
        }

        private void ddlPickTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAll.Controls.Clear();
            pnlFavourites.Controls.Clear();
            SetSelectedTeam();
            FillPanel();
        }

        private async void FillPanel()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                players = await manager.GetPlayers(GetFifaCode());
                foreach (var player in players)
                {
                    playerUC = new PlayerUC(player, this);
                    if (playerUC.PlayersUC.Favourite)
                    {
                        pnlFavourites.Controls.Add(playerUC);
                    }
                    else
                    {
                        pnlAll.Controls.Add(playerUC);
                    }
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void Panels_DragEnter(object sender, DragEventArgs e)
        {
            List<PlayerUC> multiDnD = e.Data.GetData(typeof(List<PlayerUC>)) as List<PlayerUC>;
            Control parent = multiDnD[0].Parent;
            var startingPanel = (FlowLayoutPanel)sender;
            var numberOfFavorites = pnlFavourites.Controls.Count + multiDnD.Count;

            if (startingPanel != parent)
            {
                if (parent.Name == pnlFavourites.Name)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else if (numberOfFavorites <= 3)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void Panels_DragDrop(object sender, DragEventArgs e)
        {
            var dropPanel = (FlowLayoutPanel)sender;
            List<PlayerUC> dropList = e.Data.GetData(typeof(List<PlayerUC>)) as List<PlayerUC>;

            foreach (var puc in dropList)
            {
                puc.PlayersUC.Favourite = !puc.PlayersUC.Favourite;
                puc.CheckFavourite();
            }

            if (dropPanel == pnlAll || dropPanel == pnlFavourites)
            {
                dropList.ForEach(puc => dropPanel.Controls.Add(puc));
            }

        }


        private async void btnStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                matches = await manager.GetAllMatches(GetFifaCode());
                Statistics statisticsForm = new Statistics(matches, players);
                statisticsForm.ShowDialog();

                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void FillFavoritePlayers() => FavPlayers = settingsManager.FillFavoritePlayers(FavPlayers);

        private void SetSelectedTeam() => SelectedTeam = ddlPickTeam.SelectedItem.ToString();

        private void SaveFavorites() => settingsManager.SaveFavoritePlayers(FavPlayers);

        private void SaveSelectedTeam() => settingsManager.SaveFavoriteTeam(SelectedTeam);

        private string GetFifaCode() => SelectedTeam.Substring(SelectedTeam.LastIndexOf('(') + 1, 3);

        public void DragPlayer(PlayerUC playerUC)
        {
            if (playerUC.Parent == pnlAll)
            {
                if (pnlFavourites.Controls.Count >= 3)
                {
                    Exceptions.CustomEx.ShowAlert("Can't have more than 3 players");
                    playerUC.PlayersUC.Favourite = false;
                }
                pnlFavourites.Controls.Add(playerUC);
                FavPlayers.Add(playerUC.Name, playerUC.PlayersUC.Favourite);
            }
            else
            {
                pnlAll.Controls.Add(playerUC);
                FavPlayers.Remove(playerUC.Name);
            }
            playerUC.CheckFavourite();
            SaveFavorites();
        }

        private void MainFormWF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ddlPickTeam.SelectedIndex == -1)
            {
                Application.Exit();
            }
            else SaveSelectedTeam();
        }
    }
}
