using HR.Share.PublicShare.BaseClass.AbstractClass;
using System;
using System.Windows.Controls;

namespace ClimbNetData.Windows
{
    public class HomePageProvider : UserControlBaseClass
    {

        #region 属性
        HomePage _content = null;
        #endregion

        public HomePageProvider()
        {
            this._content = new HomePage(this);
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

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
        }
    }
}
