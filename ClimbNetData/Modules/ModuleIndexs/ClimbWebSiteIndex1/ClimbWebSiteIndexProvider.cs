using HR.Share.PublicShare.BaseClass.AbstractClass;
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
