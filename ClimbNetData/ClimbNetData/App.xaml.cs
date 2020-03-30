using ClimbNetData.ViewModels;
using HR.Share.PublicShare;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using PrismUICommon.CustomRegionAdapter;
using PrismUICommon.UsingCompositeCommands.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace ClimbNetData
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        private GlobalHomeViewModel shellViewModel;
        #region prism7.0不建议使用BootStrapper了
        protected override Window CreateShell()
        {
            var globalHome = Container.Resolve<Views.GlobalHome>();
            shellViewModel = Container.Resolve<GlobalHomeViewModel>();
            //mainWindow.DataContext = shellViewModel;
            return globalHome;
            //return Container.Resolve<Views.GlobalHome>();
        }
        protected override void InitializeShell(Window shell)
        {
            //base.InitializeShell(shell);
            shellViewModel.ConfigureRegionManager();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            InitConfig();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

        }
        /// <summary>
        /// 创建ModuleCatalog,ModulePath 就是你需要加载的module的dll生成目录
        /// </summary>
        /// <returns></returns>
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    //return new DirectoryModuleCatalog();
        //    //return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        //}
        /// <summary>
        /// 配置ModuleCatalog，添加module形式变更为添加viewmodule了
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<PrismUICommon.ViewModule.UserControl1>();
            //moduleCatalog.AddModule<PrismUICommon.ViewModule.UserControl2>();

            //var moduleAType = typeof(PrismUICommon.ViewModule.UserControl1);
            //moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleAType.Name,
            //    ModuleType = moduleAType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});

            //moduleCatalog.AddModule<PrismUICommon.PrismUICommonModule>();
            moduleCatalog.AddModule<HomePage.HomePageModule>();
            moduleCatalog.AddModule<MyTask.MyTaskModule>();

            moduleCatalog.AddModule<PrismUICommon.PrismUICommonModule>();

        }
        #endregion

        #region 重写部分方法
        /// <summary>
        /// 自定义view和viewmodule的绑定，Prism是有默认绑定的(public static class ViewModelLocationProvider._defaultViewTypeToViewModelTypeResolver)
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            //方式一：通用绑定，*.xaml和*ViewModel.cs绑定
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //{
            //    var viewName = viewType.FullName;
            //    var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //    var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
            //    return Type.GetType(viewModelName);
            //});
            //方式二：指定绑定
            //ViewModelLocationProvider.Register<MainWindow, Windows.HomePageProvider>();//这里的HomePageProvider即为viewmodule

        }

        /// <summary>
        /// 注册类型和适配器之间的映射。原来只有在itemscontrol、selector和contentcontrol这三个实现了prism:RegionManager.RegionName=""可以把模块加载到控件上
        /// </summary>
        /// <param name="regionAdapterMappings"></param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(LayoutDocumentPane), Container.Resolve<LayoutDocumentPaneRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(DockingManager), Container.Resolve<AvalonDockRegionAdapter>());
        }

        ////
        //// 摘要:
        ////     /// Default view type to view model type resolver, assumes the view model is
        ////     in same assembly as the view type, but in the "ViewModels" namespace. ///
        //private static Func<Type, Type> _defaultViewTypeToViewModelTypeResolver = delegate (Type viewType)
        //{
        //    string fullName = viewType.FullName;
        //    fullName = fullName.Replace(".Views.", ".ViewModels.");
        //    string fullName2 = viewType.GetTypeInfo().Assembly.FullName;
        //    string text = fullName.EndsWith("View") ? "Model" : "ViewModel";
        //    return Type.GetType(string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", fullName, text, fullName2));
        //};
        #endregion

        #region 加载配置或其他最后需要加载的设置
        private void InitConfig()
        {
            try
            {
                GlobalClass.MyRunPath = AppDomain.CurrentDomain.BaseDirectory;
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        #endregion

    }
}
