using Prism.Regions;
using PrismUICommon.BaseClass;
using PrismUICommon.Interface;
using System;

namespace PrismUICommon.ViewModels
{
    public class WebSiteTypeAndSortViewModel : CustomICommand, MyINavigationAware
    {
        #region 私有属性
        private bool _canNavigation = false;

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
        public WebSiteTypeAndSortViewModel()
        {

        }

        #endregion
        #region 实现接口和抽象类
        public override bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteGeneric(string parameter)
        {
            throw new NotImplementedException();
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
