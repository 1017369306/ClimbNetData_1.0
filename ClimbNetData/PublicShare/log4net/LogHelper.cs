using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Lib
{
    public class LogHelper
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");//这里的 loginfo 和 log4net.config 里的名字要一样
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");//这里的 logerror 和 log4net.config 里的名字要一样
        
        /// <summary>
        /// 写普通信息到日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        /// <summary>
        /// 写普通信息和异常的详细信息到日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string info, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, ex);
            }
        }
    }
}
