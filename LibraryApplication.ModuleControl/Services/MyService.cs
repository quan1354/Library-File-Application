using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ModuleControl.Services
{
    public class MyService
    {
        public static List<VideoDescription> VideoDescriptions { get; set; }
        public class VolumeControl
        {
            public double VolumeBarHeight { get; set; } = 0;
            public Brush VolumeBarFill { get; set; } = Brushes.White;

            public VolumeControl() { }
        }
        public class Folder
        {
            public int FolderID { get; set; }
            public string Name { get; set; }
            public string SubFolder { get; set; }
        }
        [XmlRoot("Counters")]
        public class CounterData
        {
            [XmlElement("Counter")]
            public int Counter { get; set; }
        }

        public class VideoDescription
        {
            public string VideoName { get; set; }
            public string Description { get; set; }
        }

        /// <summary>
        /// IMPORTANT CLASSS
        /// </summary>
        public class Video : BindableBase
        {
            public int _videoID;
            public string _name;
            private DateTime _date;

            public string _description;
            public string _path;

            public int VideoID
            {
                get { return _videoID; }
                set
                {
                    SetProperty(ref _videoID, value);
                    //NotifyPropertyChanged(nameof(_videoID)); 
                }
            }

            public string Name
            {
                get { return _name; }
                //set { SetProperty(ref _name, value); }
                set
                {
                    SetProperty(ref _name, value);
                    //NotifyPropertyChanged(nameof(_name)); 
                }
            }

            public string Description
            {
                get { return _description; }
                set
                {
                    SetProperty(ref _description, value);
                    //NotifyPropertyChanged(nameof(_description)); 
                }
            }

            public DateTime Date
            {
                get { return _date; }
                set
                {
                    SetProperty(ref _date, value);
                    //NotifyPropertyChanged(nameof(_date)); 
                }
            }

            public string Path
            {
                get { return _path; }
                set
                {
                    SetProperty(ref _path, value);
                    //NotifyPropertyChanged(nameof(_path)); 
                }
            }
        }
        public class FolderItem : BindableBase
        {
            private string _foldername;
            private string _folderpath;
            private ObservableCollection<VideoItem> _videos;

            public string FolderPath
            {
                get => _folderpath;
                set => SetProperty(ref _folderpath, value);
            }

            public string FolderName
            {
                get => _foldername;
                set => SetProperty(ref _foldername, value);
            }

            [JsonProperty("Videos")] // Ensure this is the serialized/deserialized property
            public ObservableCollection<VideoItem> Videos
            {
                get => _videos;
                set => SetProperty(ref _videos, value);
            }

            public FolderItem()
            {
                Videos = new ObservableCollection<VideoItem>();
            }

            public FolderItem(string foldername, string folderpath)
            {
                FolderName = foldername;
                FolderPath = folderpath;
                Videos = new ObservableCollection<VideoItem>();
            }
        }



        public class VideoItem : BindableBase
        {
            [JsonProperty("VideoName")]
            public string VideoName { get; set; }

            [JsonProperty("VideoPath")]
            public string VideoPath { get; set; }

            [JsonProperty("LastModified")]
            public DateTime LastModified { get; set; }

            [JsonProperty("FileType")]
            public string FileType { get; set; }

            [JsonProperty("FileSize")]
            public string FileSize { get; set; }

            [JsonProperty("VideoLength")]
            public TimeSpan VideoLength { get; set; }

            [JsonProperty("Description")]
            public string Description { get; set; }

            public VideoItem() { }
        }

    }
}
