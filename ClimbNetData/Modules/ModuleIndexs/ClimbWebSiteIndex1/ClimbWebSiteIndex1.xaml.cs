using HR.Share.PublicShare.CustomUserControl.WpfUserControl;
using Maticsoft.Model;
using System;
using System.Windows.Controls;

namespace ClimbWebSiteIndexs
{
    /// <summary>
    /// ClimbWebSiteIndex1.xaml 的交互逻辑
    /// </summary>
    public partial class ClimbWebSiteIndex1 : UserControl
    {
        public ClimbWebSiteIndex1()
        {
            InitializeComponent();
            Init();
        }
        public ClimbWebSiteIndex1(ClimbWebSiteIndex1Provider provider)
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
                    ClimbWebSite climbWebSite = new ClimbWebSite();
                    climbWebSite.Height = 80;
                    climbWebSite.Width = 100;
                    websitebase website = new websitebase();
                    website.content = "京东" + i;
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
