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
            Time
        }

    }
}
