using ChooseModule;
using ClimbNetData.Windows;
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
                    MessageBox.Show("首页初始化失败！", "初始化", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
