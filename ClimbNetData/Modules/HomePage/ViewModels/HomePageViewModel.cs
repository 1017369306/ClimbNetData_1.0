using CommonServiceLocator;
using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using HR.Share.PublicShare.StaticBase.ClimbData;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Unity;

namespace HomePage.ViewModels
{
    /// <summary>
    /// MyINavigationAware
    /// </summary>
    public class HomePageViewModel : CustomICommand
    {
        #region 私有属性
        private bool _canNavigation = false;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        #endregion
        #region 公有属性
        public bool CanNavigation
        {
            get { return _canNavigation; }
            set
            {
                _canNavigation = value;
            }
        }

        #endregion
        #region 初始化
        public HomePageViewModel(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            ConfigureRegionManager();
        }
        public void ConfigureRegionManager()
        {
            IRegion detailsRegion = null;
            try
            {
                //var regionManager = _unityContainer.Resolve<IRegionManager>();
                //IRegionManager regionManager1 = ServiceLocator.Current.GetInstance<IRegionManager>();
                IRegion SearchText = _regionManager.Regions[RegionNames.SearchText];
                PrismUICommon.Views.SearchTextBox searchTextBox = new PrismUICommon.Views.SearchTextBox();
                SearchText.RegionManager.AddToRegion(RegionNames.SearchText, searchTextBox);
                //if (view == null) return;
                //IRegion region = RegionManager.GetRegionManager(view).Regions[RegionNames.SearchText];
                //region.Add(new HelloWorldView(), "hello");

                //PrismUICommon.Views.SearchTextBox searchTextBox = new PrismUICommon.Views.SearchTextBox();
                //detailsRegion.Add(searchTextBox, RegionNames.SearchText, true);
            }
            catch (Exception ex)
            {
                return;
            }

            //PrismUICommon.Views.SearchTextBox searchTextBox = new PrismUICommon.Views.SearchTextBox();
            ////Show a View in a Scoped Region（重复打开相同的嵌套region页面时，需使用Scoped Region来添加）
            ////IRegionManager detailsRegionManager = detailsRegion.Add(searchTextBox, null, true);
            //IRegionManager detailsRegionManager = detailsRegion.Add(searchTextBox);

            //detailsRegion.Activate(searchTextBox);
            //detailsRegion.RegionManager = detailsRegionManager;
        }

        #endregion
        #region 实现接口和抽象类
        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {

        }

        public override void ExecuteGeneric(string parameter)
        {

        }

        /// <summary>
        /// 当实现被导航到时的事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            CanNavigation = true;
        }

        /// <summary>
        /// 以确定此实例是否可以处理导航请求
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return CanNavigation;
        }

        /// <summary>
        /// 当实现者被导航离开时调用。
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            CanNavigation = false;
        }
        #endregion

        #region 事件
        //private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {

        //        Label label = (Label)sender;//FF3C55C5 #FFFFFFFF
        //        UIElementCollection collection = this.ModuleTypes.Children;
        //        foreach (System.Windows.Controls.Control item in collection)
        //        {
        //            if (item == label)
        //            {
        //                item.Background = (Brush)this.FindResource("LabelForeground1");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground3");
        //            }
        //            else
        //            {
        //                item.Background = (Brush)this.FindResource("Transparent");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground2");
        //            }
        //        }
        //        //label.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF3C55C5"));
        //        //label.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}

        //private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        Label label = (Label)sender;//FF3C55C5 #FFFFFFFF
        //        UIElementCollection collection = this.ModuleSort.Children;
        //        foreach (System.Windows.Controls.Control item in collection)
        //        {
        //            if (item == label)
        //            {
        //                item.Background = (Brush)this.FindResource("LabelForeground1");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground3");
        //            }
        //            else
        //            {
        //                item.Background = (Brush)this.FindResource("Transparent");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground2");
        //            }
        //        }
        //        //label.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF3C55C5"));
        //        //label.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}
        #endregion

    }
}
