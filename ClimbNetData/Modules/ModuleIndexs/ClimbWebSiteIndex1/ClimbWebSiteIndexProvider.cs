using HR.Share.PublicShare.BaseClass.AbstractClass;
using HR.Share.PublicShare.CustomUserControl.WpfUserControl;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClimbWebSiteIndex1
{
    public class ClimbWebSiteIndexProvider : ClimbWebSiteIndexBaseClass
    {

        ClimbWebSiteIndex _content = null;

        public ClimbWebSiteIndexProvider()
        {
            this._content = new ClimbWebSiteIndex(this);
            this.Title = "首页";
            this.Guid = System.Guid.NewGuid().ToString();
            Load();
        }

        public void Load()
        {
            try
            {
                this._content.WebSitesWrap.Children.Clear();
                for (int i = 0; i < 8; i++)
                {
                    ClimbWebSite climbWebSite = new ClimbWebSite();
                    climbWebSite.Height = 80;
                    climbWebSite.Width = 100;
                    websitebase websitebase = new websitebase();
                    websitebase.content = "京东" + i;
                    websitebase.imageUrl = new Uri(@"pack://application:,,,/PublicResources;component/Resources/Images/jd.jpg");
                    climbWebSite.DataContext = websitebase;
                    this._content.WebSitesWrap.Children.Add(climbWebSite);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override bool CloseWindows()
        {
            try
            {
                if (_content != null)
                {
                    //System.Windows.Window.GetWindow(_content).Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected override Control GetControl()
        {
            return this._content;
        }
    }
}
