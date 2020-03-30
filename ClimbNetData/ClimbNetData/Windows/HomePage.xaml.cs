using System.Windows.Controls;

namespace ClimbNetData.Windows
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : UserControl
    {

        #region 属性
        HomePageProvider _provider = null;
        #endregion

        public HomePage(HomePageProvider provider)
        {
            InitializeComponent();
            _provider = provider;

            //wpf 在用户控件里，关掉父级窗口
            //Window.GetWindow(this).Close();
        }
    }
}
