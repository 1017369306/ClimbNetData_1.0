using System;
using System.Windows;
using System.Windows.Controls;

namespace ClimbNetData.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : UserControl
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// 激活视图
        ///// </summary>
        ///// <param name="view"></param>
        //public void ViewActivate(object view)
        //{
        //    try
        //    {
        //        if (_region == null) return;
        //        if (!_region.Views.Contains(view))
        //            _region.Add(view);
        //        _region.Activate(view);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}
        ///// <summary>
        ///// 取消视图的激活
        ///// </summary>
        ///// <param name="view"></param>
        //public void ViewDeactivate(object view)
        //{
        //    try
        //    {
        //        if (_region == null) return;
        //        if (_region.Views.Contains(view))
        //            _region.Deactivate(view);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}

        /// <summary>
        /// 开始初始化
        /// </summary>
        public void Init()
        {
            try
            {
                //添加首页，且首页不能关闭
                //for (int i = 0; i < 1; i++)
                //{
                //    LayoutDocument ld = MainBaseMethod.GetLayoutDocument(new HomePageProvider());
                //    if (ld != null)
                //    {
                //        ld.CanClose = false;//首页不可以关闭
                //        DocPane1.Children.Add(ld);
                //    }
                //    else
                //    {
                //        MessageBox.Show("首页初始化失败！", "初始化", MessageBoxButton.OK, MessageBoxImage.Error);
                //        break;
                //    }
                //}
                //LayoutDocument ldTemp = MainBaseMethod.GetLayoutDocument(new ChooseClimbModuleProvider());
                //if (ldTemp != null)
                //{
                //    DocPane1.Children.Add(ldTemp);
                //}
                //else
                //{
                //    MessageBox.Show("选择模板页面初始化失败！", "初始化", MessageBoxButton.OK, MessageBoxImage.Error);
                //}

            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //把log4net主要信息输出到label显示区域
                //Log4Lib.LogHelper.AppendTextBox(this.ShowLogLabel);
                //Log4Lib.LogHelper.WriteErrorLog("异常调试。");

                //LayoutDocument ld = new LayoutDocument();
                //ld.Title = "首页";
                //ld.Content = new HomePage.Views.HomePage();
                //ld.IsActive = true;
                //ld.CanClose = false;
                //_HomePage = ld;

                //MainBaseMethod.pushTimerDateTime += RefushDateTime;
                //MainBaseMethod.InitTimer();
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
    }
}
