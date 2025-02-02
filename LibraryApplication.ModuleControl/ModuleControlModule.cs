using LibraryApplication.ModuleControl.ViewModels;
using LibraryApplication.ModuleControl.Views;
using ModuleControl.Dialogs;
using ModuleControl.ViewModels;
using ModuleControl.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleControl
{
    public class ModuleControlModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleControlModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider )
        {
            _regionManager.RegisterViewWithRegion("TopRegion", typeof(TopView));
            _regionManager.RegisterViewWithRegion("CenterRegion", typeof(HomeView));
            //_regionManager.Regions["BottomRegion"].RemoveAll();
            _regionManager.RegisterViewWithRegion("BottomRegion", typeof(BottomView));
            //_regionManager.RegisterViewWithRegion("BottomRegion2", typeof(BottomView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TopView, TopViewModel>();
            ViewModelLocationProvider.Register<CenterView, CenterViewModel>();
            ViewModelLocationProvider.Register<HomeView, HomeViewModel>();
            ViewModelLocationProvider.Register<BottomView, BottomViewModel>();
            ViewModelLocationProvider.Register<CenterView_2, CenterView_2_ViewModel>();
            ViewModelLocationProvider.Register<UpdateFormDialog, UpdateFormDialogViewModel>();
            // throw new NotImplementedException();
            containerRegistry.RegisterForNavigation<CenterView>();
            containerRegistry.RegisterForNavigation<CenterView_2>();
            containerRegistry.RegisterForNavigation<HomeView>();
        }
    }
}
