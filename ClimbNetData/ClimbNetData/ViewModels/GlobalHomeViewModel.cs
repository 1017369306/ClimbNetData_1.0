using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ClimbNetData.ViewModels
{
    public class GlobalHomeViewModel: ViewModelBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        private readonly IContainerProvider _containerProvider;
        private string _title = "墨鱼";


        public GlobalHomeViewModel(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            this.Title = _title;
            //_regionManager.Regions[RegionNames.GlobalRegion].Add(_unityContainer.Resolve<Views.MainWindow>());

        }

        //public GlobalHomeViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        //{
        //    _regionManager = regionManager;
        //    _containerProvider = containerProvider;
        //}

        public void ConfigureRegionManager()
        {
            //Inject views in regions
            _regionManager.Regions[RegionNames.GlobalRegion].Add(_unityContainer.Resolve<Views.MainWindow>());
            _regionManager.Regions[RegionNames.MenuRegion].Add(_unityContainer.Resolve<Views.MenuExpander>());
            //添加首页
            //IRegion detailsRegion = _regionManager.Regions[RegionNames.ContentRegion];
            //IRegionManager detailsRegionManager = detailsRegion.Add(_unityContainer.Resolve<HomePage.Views.HomePage>(), null, true);
            //detailsRegion.RegionManager = detailsRegionManager;
            //detailsRegion.Activate(homePage);
            //_regionManager.Regions[RegionNames.ContentRegion].Add(_unityContainer.Resolve<HomePage.Views.HomePage>(), RegionNames.ContentRegion, true);
        }

        /// <summary>
        /// 程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MainBaseMethod.StopTimer();//停止定时器
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
    }
}
