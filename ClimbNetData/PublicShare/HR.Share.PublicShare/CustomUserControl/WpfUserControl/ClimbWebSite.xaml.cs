using HR.Share.PublicShare.BaseClass.Interface;
using Maticsoft.Model;
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

namespace HR.Share.PublicShare.CustomUserControl.WpfUserControl
{
    /// <summary>
    /// ClimbWebSite.xaml 的交互逻辑
    /// </summary>
    public partial class ClimbWebSite : UserControl
    {
        private websitebase _websitebase = null;
        public ClimbWebSite()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 网站模板点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWebSite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _websitebase = this.DataContext as websitebase;
                //根据ID查询其子模板

                websitebase websitebaseNext = new websitebase();
                //websitebaseNext.content = "京东" + i;
                //websitebaseNext.moduleCount = "共" + i + "个模板";
                websitebaseNext.imageUrl = new Uri(@"pack://application:,,,/PublicResources;component/Resources/Images/jd.jpg");
                //climbWebSite.DataContext = websitebaseNext;
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
    }
}
