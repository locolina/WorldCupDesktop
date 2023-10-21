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
using WorldCupDL.Managers;

namespace WorldCupWPF
{
    
    public partial class Settings : Window
    {
        private readonly SettingsManager settingsManager = new SettingsManager();
        private MainWindow MainWindow;
        private string Championship => GetChampionship();
        public string LanguageSet => GetLanguage();

        private string GetChampionship() => rbMale.IsChecked.Value ? "Men" : "Women";
        private string GetLanguage() => rbCroatian.IsChecked.Value ? "HRV" : "ENG";

        public Settings(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckLanguage();
            CheckChampionship();
            CheckResolution();
        }

        private void CheckChampionship()
        {
            try
            {
                if (!File.Exists($"{LocalStorageConst.Settings}"))
                {
                    rbMale.IsChecked = false;
                    rbFemale.IsChecked = false;
                }
                else
                {
                    if (settingsManager.CheckForChampionshipType())
                    {
                        rbMale.IsChecked = true;
                    }
                    else
                        rbFemale.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!"); Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void CheckResolution()
        {
            if (Properties.Settings.Default.WindowState == WindowState.Maximized)
            {
                ddlResolution.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Height == 600)
            {
                ddlResolution.SelectedIndex = 1;
            }
            else if (Properties.Settings.Default.Height == 768)
            {
                ddlResolution.SelectedIndex = 2;
            }
            else if (Properties.Settings.Default.Height == 720)
            {
                ddlResolution.SelectedIndex = 3;
            }
            else
            {
                ddlResolution.SelectedIndex = -1;
            }

        }

        private void CheckLanguage()
        {
            try
            {
                if (!File.Exists($"{LocalStorageConst.Settings}"))
                {
                    rbCroatian.IsChecked = true;
                    rbEnglish.IsChecked = false;
                }
                else
                {
                    if (settingsManager.CheckForLanguage())
                    {
                        rbCroatian.IsChecked = true;
                    }
                    else
                        rbEnglish.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                Exceptions.CustomEx.ShowAlert("Woops something went wrong!");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (rbMale.IsChecked.Value == false && rbFemale.IsChecked.Value == false)
            {
                MessageBox.Show("");
                return;
            }
            else
            {
                SaveSettings();
                SaveResolution();
                RefreshMain();
                Close();
            }
        }

        private void SaveResolution()
        {
            switch (ddlResolution.SelectedIndex)
            {
                case 0:
                    WriteToSaveFile(0, 0, WindowState.Maximized);
                    return;
                case 1:
                    WriteToSaveFile(600, 800, WindowState.Normal);
                    return;
                case 2:
                    WriteToSaveFile(768, 1024, WindowState.Normal);
                    return;
                case 3:
                    WriteToSaveFile(720, 1280, WindowState.Normal);
                    return;
            }
        }

        private void WriteToSaveFile(int height, int width, WindowState state)
        {
            Properties.Settings.Default.Height = height;
            Properties.Settings.Default.Width = width;
            Properties.Settings.Default.WindowState = state;
            Properties.Settings.Default.Save();
        }

        private void RefreshMain()
        {
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            MainWindow.Close();
        }

        private void SaveSettings() => settingsManager.SaveSettings(Championship, LanguageSet);

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (rbMale.IsChecked.Value == false && rbFemale.IsChecked.Value == false)
            {
                MessageBox.Show("");
                return;
            }
            else
            {
                Close();
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape) 
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}
