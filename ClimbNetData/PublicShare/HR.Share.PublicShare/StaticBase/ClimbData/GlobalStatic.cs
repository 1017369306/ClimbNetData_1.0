using System;
using System.Collections.Generic;
using System.ComponentModel;

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
            [DescriptionAttribute("热门")]
            Hot,
            [DescriptionAttribute("本地生活")]
            LocalLife,
            [DescriptionAttribute("电子商务")]
            E_Commerce,
            [DescriptionAttribute("媒体阅读")]
            Media,
            [DescriptionAttribute("搜索引擎")]
            SearchEngine,
            [DescriptionAttribute("社交平台")]
            SocialPlatform,
            [DescriptionAttribute("科研教育")]
            Scientific,
            [DescriptionAttribute("其他")]
            Other
        }

        /// <summary>
        /// 模板排序类型
        /// </summary>
        public enum SortType
        {
            [DescriptionAttribute("热门")]
            Hot,
            [DescriptionAttribute("上线时间")]
            CreateTime
        }
        #endregion


    }
}
