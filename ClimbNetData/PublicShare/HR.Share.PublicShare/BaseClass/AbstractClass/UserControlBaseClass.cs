using HR.Share.PublicShare.ExtendsClass;

namespace HR.Share.PublicShare.BaseClass.AbstractClass
{
    /// <summary>
    /// 子窗体必须实现此抽象类
    /// </summary>
    public abstract class UserControlBaseClass : DisposePatternSample
    {
        #region 变量
        private string _guid;
        private string title = "";
        #endregion
        #region 属性
        /// <summary>
        /// GUID
        /// </summary>
        public string Guid { get { if (_guid == null || _guid.Trim() == "") _guid = System.Guid.NewGuid().ToString(); return _guid; } set => _guid = value; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get => title; set => title = value; }
        #endregion

        #region 私有方法
        #endregion

        #region 公有方法
        #endregion
        #region 派生类需要重写的函数
        protected abstract System.Windows.Controls.Control GetControl();
        public abstract bool CloseWindows();
        #endregion

        #region 重写接口
        public System.Windows.Controls.Control Control
        {
            get
            {
                return GetControl();
            }
        }
        #endregion
    }
}
