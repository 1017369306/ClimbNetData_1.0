using HR.Share.PublicShare.CustomUserControl.WpfUserControl;
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

namespace ClimbWebSiteIndexs
{
    /// <summary>
    /// ClimbWebSiteIndex2.xaml 的交互逻辑
    /// </summary>
    public partial class ClimbWebSiteIndex2 : UserControl
    {
        public ClimbWebSiteIndex2()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            try
            {
                this.WebSitesWrap.Children.Clear();
                for (int i = 0; i < 8; i++)
                {
                    ClimbWebSiteModule climbWebSite = new ClimbWebSiteModule();
                    climbWebSite.Height = 200;
                    climbWebSite.Width = 160;
                    websitebase website = new websitebase();
                    website.content = "京东商品评论";
                    website.imageUrl = new Uri(@"pack://application:,,,/PublicResources;component/Resources/Images/jd.jpg");
                    climbWebSite.DataContext = website;
                    this.WebSitesWrap.Children.Add(climbWebSite);
                }
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

    }
}
