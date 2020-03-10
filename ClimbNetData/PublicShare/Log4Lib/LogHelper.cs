using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log4Lib
{
    public class LogHelper
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");//这里的 loginfo 和 log4net.config 里的名字要一样
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");//这里的 logerror 和 log4net.config 里的名字要一样
        private static bool isAppendTextBox = false;

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
        /// 写异常日志
        /// </summary>
        /// <param name="errorMsg"></param>
        public static void WriteErrorLog(string errorMsg)
        {
            if (logerror.IsInfoEnabled)
            {
                logerror.Error(errorMsg);
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
        /// <summary>
        /// 日志同步输出到指定的textbox框中
        /// </summary>
        /// <param name="textBox"></param>
        public static void AppendTextBox(TextBoxBase textBox)
        {
            if (!isAppendTextBox)
            {
                //读取配置文件的信息  
                //log4net.ILog log1 = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                //设置textbox打印日志  
                //var logPattern = "%d{yyyy-MM-dd HH:mm:ss} --%-5p-- %m%n";
                var logPattern = "日志时间：%d [%t] %n日志级别：%-5p %n日 志 类：%c [%x] %n%m%n----------------------------------%n";
                //PatternLayout patternLayout = new PatternLayout();
                var textBox_logAppender = new TextBoxLogHelper()
                {
                    TextBox = textBox,//注释后 就只有文件log  
                    Layout = new PatternLayout(logPattern)
                };
                //相当于root标签下的   <appender-ref ref="LogFile" />  
                log4net.Config.BasicConfigurator.Configure(textBox_logAppender);
                isAppendTextBox = true;
            }
        }

        /// <summary>
        /// 日志同步输出到指定的textbox框中
        /// </summary>
        /// <param name="textBox"></param>
        public static void AppendTextBox(System.Windows.Controls.Label label)
        {
            if (!isAppendTextBox)
            {
                //读取配置文件的信息  
                //log4net.ILog log1 = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                //设置textbox打印日志  
                //var logPattern = "%d{yyyy-MM-dd HH:mm:ss} --%-5p-- %m%n";
                var logPattern = "%c %m";//只要logerror标志和message信息
                //PatternLayout patternLayout = new PatternLayout();
                var textBox_logAppender = new LabelLogHelper()
                {
                    _label = label,//注释后 就只有文件log  
                    Layout = new PatternLayout(logPattern)
                };
                //相当于root标签下的   <appender-ref ref="LogFile" />  
                log4net.Config.BasicConfigurator.Configure(textBox_logAppender);
                isAppendTextBox = true;
            }
        }
    }
}
