using ModuleControl.ViewModels;
using MyMovieApplication.Core.Events;
using Prism.Events;
using Prism.Regions;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace ModuleControl.Views
{
    public partial class CenterView : UserControl
    {
        public CenterView()
        {
            
            InitializeComponent();
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the video path from your ViewModel (CenterViewModel)
            string videoPath = ((CenterViewModel)DataContext).MediaPathUrlToStored;

            // Find the available pendrive
            string pendriveLetter = GetAvailablePendriveLetter();
            //string pendriveLetter = "D";

            if (!string.IsNullOrEmpty(pendriveLetter))
            {
                // Set the destination folder path on the pendrive
                string destinationFolderPath = $"{pendriveLetter}:\\";

                // Get the file name from the video path
                string fileName = Path.GetFileName(videoPath);

                // Build the destination file path
                string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                // Copy the video file to the destination folder
                File.Copy(videoPath, destinationFilePath, true);

                // Optionally, show a message to the user indicating that the download is complete
                MessageBox.Show("Download complete!");
            }
            else
            {
                // Handle the case when no pendrive is available
                MessageBox.Show("No pendrive detected. Please insert a pendrive to proceed download.\n 电脑未能侦测到数据盘, 请插入数据盘");
            }

        }

       

        private string GetAvailablePendriveLetter()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Removable && drive.IsReady)
                {
                    return drive.RootDirectory.FullName.Substring(0, 1);
                }
            }

            return string.Empty;
        }
    }
}
