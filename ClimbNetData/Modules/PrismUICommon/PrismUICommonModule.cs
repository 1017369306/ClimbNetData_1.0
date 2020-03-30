//using System.Linq;
using Prism.Ioc;
//using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace PrismUICommon
{
    //[ModuleExport("PrismUICommonModule", typeof(PrismUICommonModule))]
    public class PrismUICommonModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public PrismUICommonModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _unityContainer = container;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //RenderCustomFathorView();

            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //IRegion WorkSpaceRegion = regionManager.Regions["WorkSpaceRegion"];
            //var HomePage = containerProvider.Resolve<Views.HomePage>();
            //WorkSpaceRegion.Add(HomePage);
            //var ChooseClimbModule = containerProvider.Resolve<Views.ChooseClimbModule>();
            //WorkSpaceRegion.Add(ChooseClimbModule);

            //IRegion SearchText = regionManager.Regions["SearchText"];
            //var SearchTextBox = containerProvider.Resolve<Views.SearchTextBox>();
            //SearchText.Add(SearchTextBox);

            //IRegion ClimbWebSiteIndex1Region = regionManager.Regions["ClimbWebSiteIndex1"];
            //var ClimbWebSiteIndex1 = containerProvider.Resolve<Views.ClimbWebSiteIndex1>();
            //ClimbWebSiteIndex1Region.Add(ClimbWebSiteIndex1);
            //ClimbWebSiteIndex1Region.Activate(ClimbWebSiteIndex1);

            //IRegion WebSiteTypeAndSortRegion = regionManager.Regions["WebSiteTypeAndSort"];
            //var WebSiteTypeAndSort = containerProvider.Resolve<Views.WebSiteTypeAndSort>();
            //WebSiteTypeAndSortRegion.Add(WebSiteTypeAndSort);

            //IRegion NewClimbModuleRegion = regionManager.Regions["NewClimbModule"];
            //var NewClimbModule = containerProvider.Resolve<Views.NewClimbModule>();
            //NewClimbModuleRegion.Add(NewClimbModule);

            //IRegion WebSitesWrapRegion = regionManager.Regions["WebSitesWrap"];
            //var ClimbWebSite = containerProvider.Resolve<Views.ClimbWebSite>();
            //WebSitesWrapRegion.Add(ClimbWebSite);

            //IRegion regionModuleTypeRegion = regionManager.Regions["ModuleType"];
            //List<GlobalStatic.WebSiteType> webSiteTypes = MainBaseMethod.foreachEnum<GlobalStatic.WebSiteType>();
            //foreach (GlobalStatic.WebSiteType item in webSiteTypes)
            //{
            //    var tabA = containerProvider.Resolve<Views.Label1>();
            //    SetTitle(tabA, MainBaseMethod.GetEnumDescription(item));
            //    regionModuleTypeRegion.Add(tabA);
            //}

            //IRegion regionModuleSortRegion = regionManager.Regions["ModuleSort"];
            //List<GlobalStatic.SortType> sortTypes = MainBaseMethod.foreachEnum<GlobalStatic.SortType>();
            //foreach (GlobalStatic.SortType item in sortTypes)
            //{
            //    var tabA = containerProvider.Resolve<Views.Label1>();
            //    SetTitle(tabA, MainBaseMethod.GetEnumDescription(item));
            //    regionModuleSortRegion.Add(tabA);
            //}
        }
        //public void RenderCustomFathorView()
        //{
        //    IRegion ContentRegion = this._regionManager.Regions[RegionNames.ContentRegion];
        //    HomePageModule homePageModule = _unityContainer.Resolve<HomePageModule>();
        //    HomePage.Views.HomePage homePage = _unityContainer.Resolve<HomePage.Views.HomePage>();
        //    ContentRegion.Add(homePage, RegionNames.ContentRegion, true);
        //    homePageModule.DisplayHelloWorldView();
        //}
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<Views.ClimbWebSite>();
        }

        private void SetTitle(Views.Label1 tab, string content)
        {
            (tab.DataContext as ViewModels.Label1ViewModel).Content = content;
        }
    }
}
