using ModuleControl;
using ModuleControl.Services;
using ModuleControl.ViewModels;
using MyMovieApplication.Core.Commands;
using MyMovieApplication.ViewModels;
using MyMovieApplication.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using static ModuleControl.Services.MyService;

namespace MyMovieApplication
{
    public partial class App : PrismApplication
    {
        public App() {
            LoadDataFromXml();
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<ShellWindow, ShellWindowViewModel>();
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

            containerRegistry.RegisterSingleton<CenterViewModel>();
            //containerRegistry.RegisterSingleton<ShellWindow>();
            //containerRegistry.RegisterSingleton<CenterViewModel>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleControlModule>();
        }

        private void LoadDataFromXml()
        {
            // Load existing data from the XML file if it exists
            if (File.Exists("C:\\LibraryMaterial\\DescriptionData.xml"))
            {
                using (var stream = new FileStream("C:\\LibraryMaterial\\DescriptionData.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<VideoDescription>));
                    VideoDescriptions = (List<VideoDescription>)serializer.Deserialize(stream);
                    //videoDescriptions = (List<VideoDescription>)serializer.Deserialize(stream);
                }
            }
        }


    }
}
