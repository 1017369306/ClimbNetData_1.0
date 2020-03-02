using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Share.PublicShare.StaticBase.ClimbData
{
    /// <summary>
    /// 爬虫系统级静态类
    /// </summary>
    public static class GlobalStatic
    {
        #region 对象
        public static Dictionary<int, string> WebSiteModuleDic = new Dictionary<int, string>();

        #endregion

        #region 公共方法
        /// <summary>
        /// 静态类初始化
        /// </summary>
        public static void Init()
        {
            try
            {
                //WebSiteModuleDic.Add();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion


        #region enum
        /// <summary>
        /// 模板类型枚举
        /// </summary>
        public enum WebSiteType
        {
            LocalLife,
            E_Commerce,
            Media,
            SearchEngine,
            SocialPlatform,
            Scientific,
            Other
        }

        /// <summary>
        /// 模板排序类型
        /// </summary>
        public enum SortType
        {
            Hot,
            CreateTime
        }
        #endregion


    }
}
