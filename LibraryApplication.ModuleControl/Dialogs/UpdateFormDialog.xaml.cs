using ModuleControl.Services;
using System;
using System.Collections.Generic;
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
using static ModuleControl.Services.MyService;

namespace ModuleControl.Dialogs
{
    public partial class UpdateFormDialog : Window
    
    {
        public Video modifyVideo { get; set; }
        public DatabaseService _dbService;

        public UpdateFormDialog(string title, Video video, DatabaseService dbService) {
            InitializeComponent();
            dialogTitle.Text = title;
            modifyVideo = video;
            Name.Text = video.Name;
            Date.SelectedDate = video.Date;
            Path.Text = video.Path;
            Description.Text = video.Description;
            modifyVideo = video;

            _dbService = dbService;

        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e){
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            modifyVideo.Name = Name.Text;
            modifyVideo.Path = Path.Text;
            modifyVideo.Description = Description.Text;
            modifyVideo.Date = Date.SelectedDate.Value;
            _dbService.updateItem(modifyVideo);
            Close();
        }
    }
}
