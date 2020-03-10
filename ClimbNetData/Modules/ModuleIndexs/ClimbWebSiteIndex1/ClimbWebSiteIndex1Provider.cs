using HR.Share.PublicShare.BaseClass.AbstractClass;
using HR.Share.PublicShare.BindingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClimbWebSiteIndexs
{
    public class ClimbWebSiteIndex1Provider : ClimbWebSiteIndexBaseClass
    {
        #region 属性
        ClimbWebSiteIndex1 _content = null;
        private WebSitesData _webSitesData = null;

        /// <summary>
        /// 模板数据关联类(当前模板和它的父模板)，再添加一个index字段，按顺便动态加载对应的模板（0为网站，1为模板，2为模板介绍，3为配置等等）
        /// </summary>
        public WebSitesData WebSitesData { get => _webSitesData; set => _webSitesData = value; }
        #endregion

        #region 初始化
        public ClimbWebSiteIndex1Provider()
        {
            _content = new ClimbWebSiteIndex1(this);
            this.Title = "选择模板";
            Load();
        }

        /// <summary>
        /// 动态初始化模板信息
        /// </summary>
        public void Load()
        {
            try
            {
                #region 生成模板类型
                //List<GlobalStatic.WebSiteType> webSiteTypes = MainBaseMethod.foreachEnum<GlobalStatic.WebSiteType>();
                //this._content.ModuleTypes.Children.Clear();
                //foreach (GlobalStatic.WebSiteType item in webSiteTypes)
                //{
                //    Label label = new Label();
                //    label.Content = MainBaseMethod.GetEnumDescription(item);
                //    label.Margin = new System.Windows.Thickness(5, 0, 0, 0);
                //    label.Padding = new System.Windows.Thickness(5, 0, 5, 0);
                //    label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                //    label.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                //    this._content.ModuleTypes.Children.Add(label);
                //}
                #endregion

            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        #endregion

        #region 实现抽象函数
        protected override Control GetControl()
        {
            return this._content;
        }

        public override void CloseWindows()
        {
            try
            {
                base.Dispose();
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        /// <summary>
        /// 子类重写时只需清理非托管资源即可
        /// </summary>
        /// <param name="isDisposing"></param>
        protected override void Dispose(bool isDisposing)
        {
            //base.Dispose(isDisposing);
        }
        #endregion

    }
}
