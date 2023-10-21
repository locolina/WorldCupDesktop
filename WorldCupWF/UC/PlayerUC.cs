using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCupDL.Constants;
using WorldCupDL.Managers;
using WorldCupDL.Models;
using WorldCupWF.Interfaces;

namespace WorldCupWF.UC
{
    public partial class PlayerUC : UserControl
    {
        private readonly SettingsManager settingsManager = new SettingsManager();
        public Player PlayersUC { get; set; }

        private IDragable dragable;

        private string imagesFolderPath = $"{LocalStorageConst.PlayerData}";

        private static IList<PlayerUC> lPlayers = new List<PlayerUC>();

        public PlayerUC(Player player, IDragable dragable)
        {
            InitializeComponent();

            this.dragable = dragable;
            PlayersUC = player;
            this.Name = PlayersUC.Name;


            settingsManager.CheckFavoritePlayer(player);

            this.CheckFavourite();

            string imagePath = $"{imagesFolderPath}{PlayersUC.Name}.jpg";

            try
            {
                if (File.Exists(imagePath))
                {
                    imgPlayer.ImageLocation = imagePath;
                }
                else imgPlayer.ImageLocation = LocalStorageConst.PlayerImage;
            }
            catch (Exception ex)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }

            lblName.Text = PlayersUC.Name;
            lblNumber.Text = PlayersUC.ShirtNumber.ToString();
            lblPosition.Text = PlayersUC.Position.ToString();
            lblCaptain.Text = PlayersUC.Captain ? "C" : "";
        }

        public void CheckFavourite()
        {
            if (PlayersUC.Favourite)
            {
                cbFavourite.Checked = true;
            }
            else
            {
                cbFavourite.Checked = false;
            }
        }

        private void cbFavourite_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFavourite.Checked)
            {
                if (lPlayers.Count < 3)
                {
                    PlayersUC.Favourite = true;
                }
                else
                {
                    PlayersUC.Favourite = false;
                    cbFavourite.Checked = false;
                }

            }
            else
            {
                PlayersUC.Favourite = false;
            }
            dragable.DragPlayer(this);
        }

        private void imgPlayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageDialog = new OpenFileDialog
            {
                Filter = "Slike|*.bmp;*.jpg;*.png|Sve datoteke|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                imgPlayer.Image = new Bitmap(imageDialog.FileName);
                imgPlayer.Image.Save($"{imagesFolderPath}{PlayersUC.Name}.jpg");
            }
        }

        private void PlayerUC_MouseDown(object sender, MouseEventArgs e)
        {
            object data = lPlayers.Count == 0 ? new List<PlayerUC> { this } : lPlayers;

            if (e.Button == MouseButtons.Left)
            {
                if (sender is PlayerUC puc)
                {
                    puc.DoDragDrop(data, DragDropEffects.Move);
                }
            }
        }
    }
}
