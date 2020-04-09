//using HR.Share.PublicShare;
//using HR.Share.PublicShare.BaseClass.AbstractClass;
//using Prism.Ioc;
//using Prism.Modularity;
//using Prism.Regions;
//using Unity;

using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using Unity;

namespace TeamCooperation
{
    public class TeamCooperationHomePageModule : ModuleBase, IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public TeamCooperationHomePageModule(IRegionManager regionManager, IUnityContainer container)
        {
            //regionManager属性为父视图的属性，此时还没有加载当前模块的region
            _regionManager = regionManager;
            _unityContainer = container;
        }

        public override GlobalClass.MenuItems menuItem
        {
            get
            {
                return GlobalClass.MenuItems.TeamCooperation;
            }
        }

        public override void Load()
        {
            try
            {
                IRegion detailsRegion = this._regionManager.Regions[RegionNames.ContentRegion];
                Views.TeamCooperationHomePage view = new Views.TeamCooperationHomePage();
                bool createRegionManagerScope = true;
                IRegionManager detailsRegionManager = detailsRegion.Add(view, null,
                                            createRegionManagerScope);
                //detailsRegionManager.Regions[RegionNames.SearchText].Add(new PrismUICommon.Views.SearchTextBox());
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

    }
}
