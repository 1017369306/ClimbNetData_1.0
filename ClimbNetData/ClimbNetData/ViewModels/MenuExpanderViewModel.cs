using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ClimbNetData.ViewModels
{
    public class MenuExpanderViewModel : CustomICommand
    {
        IRegionManager _regionManager;
        IUnityContainer _unityContainer;

        public DelegateCommand MenuCommand { get; set; }

        public MenuExpanderViewModel(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            MenuCommand = new DelegateCommand(MenuClick, CanExecute);
        }
        private void MenuClick()
        {
            IRegion detailsRegion = null;
            try
            {
                //HomePage.Views.HomePage homePage = this._unityContainer.Resolve<HomePage.ViewModels.HomePageViewModel>();
                IRegionManager newRegionManager = this._regionManager.CreateRegionManager();
                detailsRegion = this._regionManager.Regions[RegionNames.ContentRegion];
                this._regionManager = newRegionManager;
                HomePage.Views.HomePage homePage = new HomePage.Views.HomePage();
                //newRegionManager.RegisterViewWithRegion("HomePage", this._unityContainer.Resolve<HomePage.HomePageModule>());
                IRegionManager detailsRegionManager = newRegionManager.Regions["HomePage"].Add(homePage, null, true);
                //this._regionManager = detailsRegionManager;
            }
            catch (Exception ex)
            {
                return;
            }

            //HomePage.Views.HomePage homePage = new HomePage.Views.HomePage();
            ////Show a View in a Scoped Region（重复打开相同的嵌套region页面时，需使用Scoped Region来添加）
            //IRegionManager detailsRegionManager = detailsRegion.Add(homePage, null, true);
            //IRegionManager newRegionManager = detailsRegion.RegionManager.CreateRegionManager();
            //newRegionManager = detailsRegionManager;
            //detailsRegion.Activate(homePage);


            //detailsRegion.RegionManager.AddToRegion(RegionNames.ContentRegion, homePage);

            //_regionManager.Regions[RegionNames.ContentRegion].Add(_unityContainer.Resolve<HomePage.Views.HomePage>());
        }

        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteGeneric(string parameter)
        {
            throw new NotImplementedException();
        }

    }
}
