using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MassDropProfileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConsoleContent dc = new ConsoleContent();
        DirectoryInfo profilesFolderDirectory = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\profiles");
        DirectoryInfo mdloaderFolderDirectory = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader");
        DirectoryInfo mdloader = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\mdloader_windows.exe");
        DirectoryInfo appletmdflashbinLocation = new DirectoryInfo(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\mdloader\applet-mdflash.bin");


        public MainWindow()
        {
            InitializeComponent();
            DataContext = dc;
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            refreshListBox();
        }

        private void btnFlash_Click(object sender, RoutedEventArgs e)
        {
            Scroller.ScrollToVerticalOffset(0);
            if(lbProfiles.SelectedItem != null)
            {
                if(File.Exists(mdloader.ToString()))
                {
                    if(File.Exists(appletmdflashbinLocation.ToString()))
                    {
                        DialogResult result = System.Windows.Forms.MessageBox.Show("Put keyboard into flashing mode by pressing and holding fn + b for a few seconds, " +
                            "or press the reset button on the back of the keyboard.", "Drop Keyboard Flasher", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if(result == System.Windows.Forms.DialogResult.OK)
                        {
                            dc.flash(mdloader.FullName + " --first --download " + '"' + profilesFolderDirectory.FullName + @"\" + lbProfiles.SelectedItem.ToString() + '"' + " --restart",
                                profilesFolderDirectory.FullName + @"\" + lbProfiles.SelectedItem, mdloaderFolderDirectory.FullName);
                        }
                        else
                        {
                            DialogResult result2 = System.Windows.Forms.MessageBox.Show("Cancel Flashing?", "Drop Keyboard Flasher", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if(result2 == System.Windows.Forms.DialogResult.No)
                            {
                                dc.flash(mdloader.FullName + " --first --download " + '"' + profilesFolderDirectory.FullName + @"\" + lbProfiles.SelectedItem.ToString() + '"' + " --restart",
                                    profilesFolderDirectory.FullName + @"\" + lbProfiles.SelectedItem, mdloaderFolderDirectory.FullName);
                            }
                        }
         
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("applet-md-flash.bin not found in mdloader folder. Please download it from: " +
                             "https://github.com/Massdrop/mdloader/releases and place it in mdloader folder.", "Drop Keyboard Flasher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("mdloader not found in mdloader folder. Please download it from: " +
                        "https://github.com/Massdrop/mdloader/releases and place it in mdloader folder.", "Drop Keyboard Flasher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No profile is selected.", "Drop Keyboard Flasher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigure_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Make sure to download firmware to profiles folder.", "Drop Keyboard Flasher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("https://drop.com/mechanical-keyboards/configurator");
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            refreshListBox();
        }

        private void refreshListBox ()
        {
            lbProfiles.Items.Clear();
            FileInfo[] Files = profilesFolderDirectory.GetFiles("*.bin");
            foreach (FileInfo file in Files)
            {
                lbProfiles.Items.Add(file);
            }
        }
    }

    public class ConsoleContent : INotifyPropertyChanged
    {
        string consoleInput = string.Empty;
        ObservableCollection<string> consoleOutput = new ObservableCollection<string>() { "Compile Output..." };

        public string ConsoleInput
        {
            get
            {
                return consoleInput;
            }
            set
            {
                consoleInput = value;
                OnPropertyChanged("ConsoleInput");
            }
        }

        public ObservableCollection<string> ConsoleOutput
        {
            get
            {
                return consoleOutput;
            }
            set
            {
                consoleOutput = value;
                OnPropertyChanged("ConsoleOutput");
            }
        }

        public void flash(string command, string filelocation, string mdloaderfolder)
        {
            ConsoleOutput = new ObservableCollection<string>();
            ConsoleOutput.Add("Flashing " + filelocation);
            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = mdloaderfolder
                };

                p.Start();
                p.StandardInput.WriteLine(command);
                p.StandardInput.WriteLine("exit");
                ConsoleOutput.Add(p.StandardOutput.ReadToEnd());
                p.WaitForExit();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
