using WorldCupDL.Constants;
using WorldCupDL.Managers;

namespace WorldCupWF
{
    public partial class Settings : Form
    {
        private readonly SettingsManager settingsManager = new SettingsManager();
        private MainFormWF MainFormWF;

        private string Championship => ddlGender.SelectedItem.ToString() == "Men" ? "Men" : "Woman";
        private string Language => ddlLanguage.SelectedItem.ToString() == "HRV" ? "HRV" : "ENG";

        public Settings(MainFormWF mainFormWF)
        {
            InitializeComponent();
            MainFormWF = mainFormWF;
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MainFormWF.SetForm();
            Close();
        }

        private void SaveSettings() => settingsManager.SaveSettings(Championship, Language);

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(LocalStorageConst.Settings))
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else
                {
                    ddlLanguage.SelectedIndex = settingsManager.CheckForLanguage() ? 0 : 1;
                }
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
            try
            {
                if (!File.Exists(LocalStorageConst.Settings))
                {
                    ddlGender.SelectedIndex = 0;
                }
                else
                {
                    ddlGender.SelectedIndex = settingsManager.CheckForChampionshipType() ? 0 : 1;
                }
            }
            catch (Exception)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void btnOk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void btnCancel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}
