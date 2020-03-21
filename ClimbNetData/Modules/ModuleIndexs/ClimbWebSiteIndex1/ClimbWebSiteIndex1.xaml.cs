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
                    climbWebSite.MouseLeftButtonDown += ClimbWebSite_MouseLeftButtonDown;
                    climbWebSite.Height = 200;
                    climbWebSite.Width = 160;
                    websitebase website = new websitebase();
                    website.content = "京东" + i;
                    website.moduleCount = "共" + i + "个模板";
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

        private void ClimbWebSite_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                ClimbWebSite CurrentClimbWebSite = (ClimbWebSite)sender;
                websitebase temp = CurrentClimbWebSite.DataContext as websitebase;
                if (temp.index == 1)
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
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
    }
}
