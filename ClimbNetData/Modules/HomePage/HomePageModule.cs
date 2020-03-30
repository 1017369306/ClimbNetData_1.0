using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using Unity;

namespace HomePage
{
    public class HomePageModule : ModuleBase, IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;


        #region 实现IModuleBase的接口
        public override GlobalClass.MenuItems menuItem
        {
            get
            {
                return GlobalClass.MenuItems.HomePage;
            }
        }

        /// <summary>
        /// 加载首页功能
        /// </summary>
        public override void Load()
        {
            try
            {
                IRegion detailsRegion = this._regionManager.Regions[RegionNames.ContentRegion];
                HomePage.Views.HomePage view = new HomePage.Views.HomePage();
                bool createRegionManagerScope = true;
                IRegionManager detailsRegionManager = detailsRegion.Add(view, "首页",
                                            createRegionManagerScope);
                detailsRegionManager.Regions[RegionNames.SearchText].Add(new PrismUICommon.Views.SearchTextBox());
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        #endregion

        public HomePageModule(IRegionManager regionManager, IUnityContainer container)
        {
            //regionManager属性为父视图的属性，此时还没有加载当前模块的region
            _regionManager = regionManager;
            _unityContainer = container;
            //首次加载时加载首页
            IRegionManager AllRegionManager = _unityContainer.Resolve<IRegionManager>();
            if (AllRegionManager.Regions[RegionNames.ContentRegion].GetView("首页") == null)
            {
                Load();
            }
        }

        public void RenderHomePage()
        {
            //添加首页
            IRegion ContentRegion = this._regionManager.Regions[RegionNames.ContentRegion];
            PrismUICommon.Views.SearchTextBox searchTextBox = new PrismUICommon.Views.SearchTextBox();
            //SearchTextBox.SearchTextBoxModule searchTextBoxModule = _unityContainer.Resolve<SearchTextBox.SearchTextBoxModule>();
            ContentRegion.Add(searchTextBox);
            //searchTextBoxModule.DisplaySearchTextBox();


            //IRegion SearchText = this._regionManager.Regions[RegionNames.SearchText];
            //PrismUICommon.Views.SearchTextBox searchTextBox = new PrismUICommon.Views.SearchTextBox();
            //SearchText.RegionManager.AddToRegion(RegionNames.SearchText, searchTextBox);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            try
            {
                //RenderHomePage();

                //IRegion detailsRegion = this._regionManager.Regions[RegionNames.ContentRegion];
                //PrismUICommon.Views.SearchTextBox searchTextBox = new PrismUICommon.Views.SearchTextBox();
                ////Show a View in a Scoped Region（重复打开相同的嵌套region页面时，需使用Scoped Region来添加）
                ////IRegionManager detailsRegionManager = detailsRegion.Add(searchTextBox, null, true);
                //IRegionManager detailsRegionManager = detailsRegion.Add(searchTextBox);
            }
            catch (Exception ex)
            {

            }

            //detailsRegion.Activate(searchTextBox);
            //var regionManager = containerProvider.Resolve<IRegionManager>();

            //_regionManager.Regions[RegionNames.SearchText].Add(containerProvider.Resolve<PrismUICommon.Views.SearchTextBox>());

            //IRegion SearchTextRegion = regionManager.Regions["SearchText"];
            //var SearchText = containerProvider.Resolve<PrismUICommon.Views.SearchTextBox>();
            //SearchTextRegion.Add(SearchText);
            //var HomePage = containerProvider.Resolve<View.HomePage>();
            //WorkSpaceRegion.Add(HomePage);
            //var ChooseClimbModule = containerProvider.Resolve<View.ChooseClimbModule>();
            //WorkSpaceRegion.Add(ChooseClimbModule);

            //IRegion SearchText = regionManager.Regions["SearchText"];
            //var SearchTextBox = containerProvider.Resolve<View.SearchTextBox>();
            //SearchText.Add(SearchTextBox);

            //IRegion ClimbWebSiteIndex1Region = regionManager.Regions["ClimbWebSiteIndex1"];
            //var ClimbWebSiteIndex1 = containerProvider.Resolve<View.ClimbWebSiteIndex1>();
            //ClimbWebSiteIndex1Region.Add(ClimbWebSiteIndex1);
            //ClimbWebSiteIndex1Region.Activate(ClimbWebSiteIndex1);

            //IRegion WebSiteTypeAndSortRegion = regionManager.Regions["WebSiteTypeAndSort"];
            //var WebSiteTypeAndSort = containerProvider.Resolve<View.WebSiteTypeAndSort>();
            //WebSiteTypeAndSortRegion.Add(WebSiteTypeAndSort);

            //IRegion NewClimbModuleRegion = regionManager.Regions["NewClimbModule"];
            //var NewClimbModule = containerProvider.Resolve<View.NewClimbModule>();
            //NewClimbModuleRegion.Add(NewClimbModule);

            //IRegion WebSitesWrapRegion = regionManager.Regions["WebSitesWrap"];
            //var ClimbWebSite = containerProvider.Resolve<View.ClimbWebSite>();
            //WebSitesWrapRegion.Add(ClimbWebSite);

            //IRegion regionModuleTypeRegion = regionManager.Regions["ModuleType"];
            //List<GlobalStatic.WebSiteType> webSiteTypes = MainBaseMethod.foreachEnum<GlobalStatic.WebSiteType>();
            //foreach (GlobalStatic.WebSiteType item in webSiteTypes)
            //{
            //    var tabA = containerProvider.Resolve<View.Label1>();
            //    SetTitle(tabA, MainBaseMethod.GetEnumDescription(item));
            //    regionModuleTypeRegion.Add(tabA);
            //}

            //IRegion regionModuleSortRegion = regionManager.Regions["ModuleSort"];
            //List<GlobalStatic.SortType> sortTypes = MainBaseMethod.foreachEnum<GlobalStatic.SortType>();
            //foreach (GlobalStatic.SortType item in sortTypes)
            //{
            //    var tabA = containerProvider.Resolve<View.Label1>();
            //    SetTitle(tabA, MainBaseMethod.GetEnumDescription(item));
            //    regionModuleSortRegion.Add(tabA);
            //}
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<View.ClimbWebSite>();
        }

        //private void SetTitle(View.Label1 tab, string content)
        //{
        //    (tab.DataContext as ViewModels.Label1ViewModel).Content = content;
        //}
    }
}
