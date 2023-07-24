using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using static ModuleControl.Services.MyService;

namespace LibraryApplication.ModuleControl.Dialogs
{
    public partial class AddDescriptionDialog : Window
    {
        private List<VideoDescription> videoDescriptions { get; set; }
        public AddDescriptionDialog(ObservableCollection<VideoItem> videos)
        {
            InitializeComponent();
            AvailableVideos.ItemsSource = videos;

            //LoadDataFromXml();
            if (VideoDescriptions != null)
            {
                videoDescriptions = VideoDescriptions;
            }
            else {
                videoDescriptions = new List<VideoDescription>();
            }
            AvailableVideos.SelectedIndex = 0;
        }


        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            string selectedVideoName = (AvailableVideos.SelectedItem as VideoItem)?.VideoName;
            string textBoxContent = DescriptionBox.Text;

            if (videoDescriptions != null && videoDescriptions.Any(description => description.VideoName == selectedVideoName))
            {

                // Update the existing description with the new content
                var existingDescription = videoDescriptions.FirstOrDefault(description => description.VideoName == selectedVideoName);
                existingDescription.Description = textBoxContent;
            }
            else {
                // Create a new VideoDescription object with the selected video name and TextBox content
                VideoDescription newDescription = new VideoDescription
                {
                    VideoName = selectedVideoName,
                    Description = textBoxContent
                };
                videoDescriptions.Add(newDescription);
                VideoDescriptions = videoDescriptions;
            }
            
            // Add the new VideoDescription to the list
            
            SaveDataToXml();
        }

        //private void SaveDataToXml()
        //{
        //    // Save the videoDescriptions list to the XML file
        //    using (var stream = new FileStream("../../../LibraryApplication.ModuleControl/Data/DescriptionData.xml", FileMode.Create))
        //    {
        //        XmlWriterSettings settings = new XmlWriterSettings
        //        {
        //            Indent = true,
        //            NewLineHandling = NewLineHandling.Entitize // Handles new lines correctly
        //        };
        //        XmlSerializer serializer = new XmlSerializer(typeof(List<VideoDescription>));
        //        using (XmlWriter writer = XmlWriter.Create(stream, settings))
        //        {
        //            serializer.Serialize(writer, videoDescriptions);
        //        }
        //    }
        //}

        private void SaveDataToXml()
        {
            // Save the videoDescriptions list to the XML file
            using (var memoryStream = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineHandling = NewLineHandling.Entitize // Handles new lines correctly
                };

                XmlSerializer serializer = new XmlSerializer(typeof(List<VideoDescription>));
                using (XmlWriter writer = XmlWriter.Create(memoryStream, settings))
                {
                    serializer.Serialize(writer, videoDescriptions);
                }

                // Copy the content of the MemoryStream to the file
                File.WriteAllBytes("C:\\LibraryMaterial\\DescriptionData.xml", memoryStream.ToArray());
                MessageBox.Show("UPDATE SUCCESS", "Description Status");
                DescriptionBox.Text = "";
            }
        }

        private void AvailableVideos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Set the TextBox text to display the description content of the selected video name
            string selectedVideoName = (AvailableVideos.SelectedItem as VideoItem)?.VideoName;
            if (videoDescriptions != null)
            {
                VideoDescription selectedDescription = videoDescriptions.FirstOrDefault(description => description.VideoName == selectedVideoName);
                if (selectedDescription != null)
                {
                    DescriptionBox.Text = selectedDescription.Description;
                }
                else
                {
                    DescriptionBox.Text = string.Empty;
                }
            }
        }
    }
}
