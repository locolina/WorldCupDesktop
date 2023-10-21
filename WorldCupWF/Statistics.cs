using System.ComponentModel;
using WorldCupDL.Constants;
using WorldCupDL.Models;

namespace WorldCupWF
{
    public partial class Statistics : Form
    {
        private IList<WorldCupDL.Models.Match> Matches { get; set; }
        private ISet<Player> Players { get; set; }

        private string savedImage = LocalStorageConst.PlayerImage;
        private string defaultImage = LocalStorageConst.PlayerImage;



        public Statistics(IList<WorldCupDL.Models.Match> matches, ISet<Player> players)
        {
            InitializeComponent();
            Matches = matches;
            Players = players;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            try
            {
                GetplayerStat();
                GetMatchStat();
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void GetMatchStat()
        {
            matchStat.DataSource = Matches;
            matchStat.Columns["Venue"].Visible = false;
            matchStat.Columns["Status"].Visible = false;
            matchStat.Columns["Time"].Visible = false;
            matchStat.Columns["FifaId"].Visible = false;
            matchStat.Columns["Weather"].Visible = false;
            matchStat.Columns["StageName"].Visible = false;
            matchStat.Columns["HomeTeamCountry"].Visible = false;
            matchStat.Columns["AwayTeamCountry"].Visible = false;
            matchStat.Columns["Datetime"].Visible = false;
            matchStat.Columns["Winner"].Visible = false;
            matchStat.Columns["WinnerCode"].Visible = false;
            matchStat.Columns["HomeTeamStatistics"].Visible = false;
            matchStat.Columns["LastEventUpdateAt"].Visible = false;
            matchStat.Columns["LastScoreUpdateAt"].Visible = false;
            matchStat.Columns["AwayTeamStatistics"].Visible = false;
        }

        private void GetplayerStat()
        {
            List<Player> players = Players.ToList();

            playerStat.DataSource = players;
            playerStat.Columns["PlayersTeam"].Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e) => printPreviewDialog1.ShowDialog();

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap PrintBitmapMatches = new Bitmap(matchStat.Width, matchStat.Height);
            matchStat.DrawToBitmap(PrintBitmapMatches, new Rectangle(0, 0, matchStat.Width, matchStat.Height));
            e.Graphics.DrawImage(PrintBitmapMatches, 0, 50);

            Bitmap PrintBitmapPlayers = new Bitmap(playerStat.Width, playerStat.Height);
            playerStat.DrawToBitmap(PrintBitmapPlayers, new Rectangle(0, 0, playerStat.Width, playerStat.Height));
            e.Graphics.DrawImage(PrintBitmapPlayers, 0, matchStat.Height + 100);
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            List<Player> players = Players.ToList();

            if (radioGoals.Checked)
            {
                players.Sort((p1, p2) => -p1.GoalsScored.CompareTo(p2.GoalsScored));
            }
            else
            {
                players.Sort((p1, p2) => -p1.YellowCards.CompareTo(p2.YellowCards));
            }

            playerStat.DataSource = players;
            playerStat.Columns["PlayersTeam"].Visible = false;
        }

    }
}
