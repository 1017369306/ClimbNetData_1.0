using ChooseModule;
using ClimbNetData.Windows;
using ClimbWebSiteIndexs;
using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace ClimbNetData
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 开始初始化
        /// </summary>
        public void Init()
        {
            try
            {
                //添加首页，且首页不能关闭
                for (int i = 0; i < 1; i++)
                {
                    LayoutDocument ld = MainBaseMethod.GetLayoutDocument(new HomePageProvider());
                    if (ld != null)
                    {
                        ld.CanClose = false;//首页不可以关闭
                        DocPane1.Children.Add(ld);
                    }
                    else
                    {
                        MessageBox.Show("首页初始化失败！", "初始化", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
                LayoutDocument ldTemp = MainBaseMethod.GetLayoutDocument(new ChooseClimbModuleProvider());
                if (ldTemp != null)
                {
                    DocPane1.Children.Add(ldTemp);
                }
                else
                {
                    MessageBox.Show("选择模板页面初始化失败！", "初始化", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                LayoutDocument ldTemp1 = MainBaseMethod.GetLayoutDocument(new ClimbWebSiteIndex1Provider());
                if (ldTemp1 != null)
                {
                    DocPane1.Children.Add(ldTemp1);
                }
                else
                {
                    MessageBox.Show("选择模板页面初始化失败！", "初始化", MessageBoxButton.OK, MessageBoxImage.Error);
                }

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
                Log4Lib.LogHelper.AppendTextBox(this.ShowLogLabel);
                Log4Lib.LogHelper.WriteErrorLog("异常调试。");
                MainBaseMethod.pushTimerDateTime += RefushDateTime;
                MainBaseMethod.InitTimer();
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        private void RefushDateTime(DateTime dateTime)
        {
            try
            {
                this.FooterDateTime.Content = dateTime.ToString();
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
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
