using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MassDropProfileManager
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        bool saved = false;
        public Settings()
        {
            InitializeComponent();
            if(Properties.Settings.Default.UseDefaultProfileFolder)
            {
                tbProfileFolderLocation.IsEnabled = false;
                btnBrowse.IsEnabled = false;
            }
            chkUseDefault.IsChecked = Properties.Settings.Default.UseDefaultProfileFolder;
            tbProfileFolderLocation.Text = Properties.Settings.Default.ProfileFolderLocation;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = Properties.Settings.Default.ProfileFolderLocation;
            folderDialog.ShowDialog();
            tbProfileFolderLocation.Text = folderDialog.SelectedPath;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (!saved)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to save these settings?", "Drop Keyboard Flasher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if (new DirectoryInfo(tbProfileFolderLocation.Text).Exists)
                    {
                        saved = true;
                        Properties.Settings.Default.ProfileFolderLocation = tbProfileFolderLocation.Text;
                        Properties.Settings.Default.UseDefaultProfileFolder = (bool)chkUseDefault.IsChecked;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!saved)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to save these settings?", "Drop Keyboard Flasher", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if (new DirectoryInfo(tbProfileFolderLocation.Text).Exists)
                    {
                        Properties.Settings.Default.ProfileFolderLocation = tbProfileFolderLocation.Text;
                        Properties.Settings.Default.UseDefaultProfileFolder = (bool)chkUseDefault.IsChecked;
                        Properties.Settings.Default.Save();
                    }
                    this.Close();
                }
                else if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if(!saved)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to leave without saving these settings?", "Drop Keyboard Flasher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void chkUseDefault_Unchecked(object sender, RoutedEventArgs e)
        {
            btnBrowse.IsEnabled = true;
            tbProfileFolderLocation.IsEnabled = true;
            tbProfileFolderLocation.Text = "";
            saved = false;
        }

        private void chkUseDefault_Checked(object sender, RoutedEventArgs e)
        {
            btnBrowse.IsEnabled = false;
            tbProfileFolderLocation.IsEnabled = false;
            tbProfileFolderLocation.Text = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\profiles").FullName;
            saved = false;
        }

        private void tbProfileFolderLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            saved = false;
        }
    }
}
