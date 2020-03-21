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

namespace HomePage.Views
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }
        //#region 属性
        //HomePageProvider _provider = null;
        //#endregion

        //public HomePage(HomePageProvider provider)
        //{
        //    InitializeComponent();
        //    _provider = provider;

        //    //wpf 在用户控件里，关掉父级窗口
        //    //Window.GetWindow(this).Close();
        //}
    }
}
