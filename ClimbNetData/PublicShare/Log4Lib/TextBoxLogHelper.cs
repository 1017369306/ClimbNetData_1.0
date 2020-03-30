using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using System;
using System.Drawing;
using System.Windows.Forms;

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
    public class TextBoxLogHelper : AppenderSkeleton
    {
        public TextBoxBase TextBox { get; set; }

        public TextBoxLogHelper()
        {

        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (this.TextBox == null)
            {
                return;
            }

            if (!this.TextBox.IsHandleCreated)
            {
                return;
            }

            if (this.TextBox.IsDisposed)
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

            if (!this.TextBox.InvokeRequired)
            {
                printf(str);
            }
            else
            {
                this.TextBox.BeginInvoke((MethodInvoker)delegate
                {
                    if (!this.TextBox.IsHandleCreated)
                    {
                        return;
                    }

                    if (this.TextBox.IsDisposed)
                    {
                        return;
                    }
                    printf(str);
                });
            }
        }

        private void printf(string str)
        {
            //若是超过10行 则清除  
            if (TextBox.Lines.Length > 50)
            {
                TextBox.Clear();
            }
            if (str == string.Empty || str.Trim() == "") return;

            //为异常时变色
            if (this.TextBox is RichTextBox && (str.Contains("logerror")))
            {
                RichTextBox richTextBox = (RichTextBox)this.TextBox;
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.SelectionLength = str.Length;
                richTextBox.SelectionColor = Color.Red;
            }
            this.TextBox.AppendText(str);
            //让文本框获取焦点
            this.TextBox.Focus();
            //设置光标的位置到文本尾
            this.TextBox.Select(this.TextBox.TextLength, 0);
            //滚动到控件光标处
            this.TextBox.ScrollToCaret();
        }

        public static void Append()
        {

        }
    }
}
