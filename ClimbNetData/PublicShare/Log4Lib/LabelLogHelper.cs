using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using System;
using System.Windows.Controls;

namespace Log4Lib
{
    /// <summary>  
    /// Usage:  
    ///     log4net.Config.BasicConfigurator.Configure();  
    ///     var logPattern = "%date [%thread] %-5level %logger !%M - %message%newline";  
    ///     var logAppender = new TextBoxBaseAppender()  
    ///     {  
    ///         TextBox = this.textBox2,  
    ///         Layout = new PatternLayout(logPattern)  
    ///     };  
    ///       
    ///     ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetLoggerRepository()).Root.AddAppender(logAppender);  
    /// </summary>  
    public class LabelLogHelper : AppenderSkeleton
    {
        public Label _label { get; set; }

        public LabelLogHelper()
        {

        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (this._label == null)
            {
                return;
            }

            var patternLayout = this.Layout as PatternLayout;

            var str = string.Empty;
            if (patternLayout != null)
            {
                str = patternLayout.Format(loggingEvent);

                if (loggingEvent.ExceptionObject != null)
                {
                    str += loggingEvent.ExceptionObject.ToString() + Environment.NewLine;
                }
            }
            else
            {
                str = loggingEvent.LoggerName + "-" + loggingEvent.RenderedMessage + Environment.NewLine;
            }
            this._label.Dispatcher.BeginInvoke(new Action(delegate
            {
                printf(str);
            }));
        }

        private void printf(string str)
        {
            if (str == string.Empty || str.Trim() == "") return;
            this._label.Content = "";
            //默认黑色
            this._label.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFBBBBBB"));
            if (str.Contains("logerror"))
            {
                this._label.Content = str.Replace("logerror", "");
                this._label.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFB20F0F"));
                return;
            }
            this._label.Content = str;
        }

        public static void Append()
        {

        }
    }
}
