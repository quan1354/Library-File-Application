using ModuleControl.Services;
using MyMovieApplication.Core.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleControl.ViewModels
{
    public class UpdateFormDialogViewModel : BindableBase
    {
        public IApplicationCommands _applicationCommands;
        private DatabaseService _databaseService { get; set; }


        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }

        }

        public UpdateFormDialogViewModel(IApplicationCommands applicationCommands, DatabaseService databaseService) {
            ApplicationCommands = applicationCommands;
            _databaseService = databaseService;
        }
    }
}
