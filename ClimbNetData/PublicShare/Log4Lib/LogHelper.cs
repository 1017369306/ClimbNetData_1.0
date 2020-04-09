using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.UI;
using log4net.Layout;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Log4Lib
{
    public class LogHelper
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");//这里的 loginfo 和 log4net.config 里的名字要一样
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");//这里的 logerror 和 log4net.config 里的名字要一样
        private static bool isAppendTextBox = false;

        private static CustomToastViewModel customToastViewModel { get; set; }
        private static string CustomNotificationText { get; set; }
        private static double CustomNotificationWidth { get; set; }
        private static double CustomNotificationHeight { get; set; }
        private static Color CustomNotificationBackground { get; set; }
        private static SolidColorBrush CustomNotificationBackgroundBrush { get; set; }

        private static NotificationService _myNotificationService;
        private static void InitNotificationService()
        {
            try
            {
                CustomNotificationWidth = 380;
                CustomNotificationHeight = 100;
                CustomNotificationBackground = Color.FromRgb(34, 188, 234);
                CustomNotificationBackgroundBrush= new SolidColorBrush { Color = CustomNotificationBackground };
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 右下角提示框对象
        /// </summary>
        [ServiceProperty(Key = "ServiceWithDefaultNotifications")]
        protected static NotificationService MyNotificationService
        {
            get
            {
                if (_myNotificationService == null)
                {
                    InitNotificationService();
                    //加载资源词典
                    //ResourceDictionary resourceDictionary = new ResourceDictionary();
                    //System.Windows.Application.LoadComponent(resourceDictionary, new Uri("/Log4Lib;component/Style/CustomNotificationTemplate.xaml", UriKind.Relative));
                    //System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

                    _myNotificationService = new NotificationService();
                    _myNotificationService.ApplicationId = "sample_notification_app";
                    _myNotificationService.CustomNotificationTemplate = (DataTemplate)System.Windows.Application.Current.FindResource("CustomNotificationTemplate");
                    _myNotificationService.CustomNotificationStyle = (Style)System.Windows.Application.Current.FindResource("CustomNotificationStyle");
                    _myNotificationService.CustomNotificationScreen = NotificationScreen.Primary;
                    //_myNotificationService.PredefinedNotificationTemplate = NotificationTemplate.ShortHeaderAndTwoTextFields;
                    _myNotificationService.CustomNotificationPosition = NotificationPosition.BottomRight;
                }
                return _myNotificationService;
            }
        }

        //
        // 摘要:
        //     ///
        //     Creates and returns a predefined notification with the specified header, and
        //     body text and image.
        //     ///
        //
        // 参数:
        //   text1:
        //     The System.string value specifying the notification header.
        //
        //   text2:
        //     The System.String value specifying the notification's body text1.
        //
        //   text3:
        //     The System.String value specifying the notification's body text2.
        //
        //   image:
        //     An ImageSource object that represents the notification image.
        //
        // 返回结果:
        //     An DevExpress.Mvvm.INotification descendant with the with the specified header,
        //     and body text and image.
        protected static void ShowNotification(string text1, string text2, string text3, ImageSource image = null)
        {
            try
            {
                //ImageSource image = ShowImage ? new BitmapImage(new Uri("pack://application:,,,/HR.Share.PublicShare;component/Resources/jd.jpg", UriKind.Absolute)) : null;
                //ImageSource image = null;
                //string text1 = "Lorem ipsum dolor sit amet integer fringilla, dui eget ultrices cursus, justo tellus.";
                //string text2 = "In ornare ante magna, eget volutpat mi bibendum a. Nam ut ullamcorper libero. Pellentesque habitant.";
                //string text3 = "Quisque sapien odio, mollis tincidunt est id, fringilla euismod neque. Aenean adipiscing lorem dui, nec. ";
                if (MyNotificationService == null) return;
                //DevExpress.Mvvm.INotification notification = MyNotificationService.CreatePredefinedNotification(text1, text2, text3, image);
                //notification.ShowAsync();

                customToastViewModel = ViewModelSource.Create(() => new CustomToastViewModel
                {
                    Text1 = text1,
                    Text2 = text2,
                    Text3 = text3,
                    Image = image,
                    Width = CustomNotificationWidth,
                    Height = CustomNotificationHeight,
                    Background = CustomNotificationBackgroundBrush
                });

                DevExpress.Mvvm.INotification CustomNotification = MyNotificationService.CreateCustomNotification(customToastViewModel);
                CustomNotification.ShowAsync();
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

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
        /// 写普通信息到日志并弹提示框
        /// </summary>
        /// <param name="text1">标题</param>
        /// <param name="image">图片</param>
        /// <param name="log1">提示框第一行信息</param>
        /// <param name="log2">提示框第二行信息</param>
        public static void WriteLog(string text1, ImageSource image, string log1, string log2 = null)
        {
            if (loginfo.IsInfoEnabled)
            {
                string log = log1 + "\r\n" + log2;
                loginfo.Info(log);
                ShowNotification(text1, log1, log2, image);
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
        /// 写异常日志
        /// </summary>
        /// <param name="text1">标题</param>
        /// <param name="image">图片</param>
        /// <param name="errorMsg1">提示框第一行信息</param>
        /// <param name="errorMsg1">提示框第二行信息</param>
        public static void WriteErrorLog(string text1, ImageSource image, string errorMsg1, string errorMsg2 = null)
        {
            if (logerror.IsInfoEnabled)
            {
                string log = errorMsg1 + "\r\n" + errorMsg2;
                logerror.Error(log);
                ShowNotification(text1, errorMsg1, errorMsg2, image);
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
        /// 写普通信息和异常的详细信息到日志
        /// </summary>
        /// <param name="text1">标题</param>
        /// <param name="image">图片</param>
        /// <param name="errorMsg1">提示框第一行信息</param>
        /// <param name="ex">异常</param>
        /// <param name="errorMsg2">提示框第二行信息</param>
        public static void WriteLog(string text1, ImageSource image, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(ex.Message, ex);
                ShowNotification(text1, ex.Message, null, image);
            }
        }
        //public static void WriteWarning(string info)
        //{
        //    if (logerror.IsErrorEnabled)
        //    {
        //        loginfo.Info(info);
        //        ShowNotification(LogType.Warning.ToString(), info, null, null);
        //    }
        //}
        //public static void WriteQuestion(string info)
        //{
        //    if (logerror.IsErrorEnabled)
        //    {
        //        loginfo.Info(info);
        //        ShowNotification(LogType.Question.ToString(), info, null, null);
        //    }
        //}

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

    [POCOViewModel]
    public class CustomToastViewModel
    {
        public virtual string Text1 { get; set; }
        public virtual string Text2 { get; set; }
        public virtual string Text3 { get; set; }
        public virtual ImageSource Image { get; set; }
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }
        public virtual SolidColorBrush Background { get; set; }
    }
}
