using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Media;

namespace HR.Share.PublicShare.BaseClass
{
    //[POCOViewModel]
    public abstract class ViewModelBase : BindableBase
    {
        #region 私有属性
        private string _guid = null;
        private ImageSource _iconKey = null;
        private string _title = null;
        private string _description = null;
        private bool _canClose = true;
        private bool _canFloat = true;
        private bool _canMove = true;
        private bool _canTogglePin = true;
        private bool _isEnabled;
        //private NotificationService _myNotificationService;
        ///// <summary>
        ///// 右下角提示框对象
        ///// </summary>
        //[ServiceProperty(Key = "ServiceWithDefaultNotifications")]
        //protected virtual NotificationService MyNotificationService
        //{
        //    get
        //    {
        //        if (_myNotificationService == null)
        //        {
        //            _myNotificationService = new NotificationService();
        //            _myNotificationService.ApplicationId = "sample_notification_app";
        //            _myNotificationService.PredefinedNotificationTemplate = NotificationTemplate.ShortHeaderAndTwoTextFields;
        //            _myNotificationService.CustomNotificationPosition = NotificationPosition.BottomRight;
        //        }
        //        return _myNotificationService;
        //    }
        //}
        #endregion

        #region 公共属性，实现类可以设置窗体或自定义控件的属性
        public string Guid { get => _guid; set => _guid = value; }
        public ImageSource IconKey { get => _iconKey; set => _iconKey = value; }
        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public bool CanClose { get => _canClose; set => _canClose = value; }
        public bool CanFloat { get => _canFloat; set => _canFloat = value; }
        public bool CanMove { get => _canMove; set => _canMove = value; }
        public bool CanTogglePin { get => _canTogglePin; set => _canTogglePin = value; }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
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
        //protected void ShowNotification(string text1, string text2, string text3, ImageSource image = null)
        //{
        //    try
        //    {
        //        //ImageSource image = ShowImage ? new BitmapImage(new Uri("pack://application:,,,/HR.Share.PublicShare;component/Resources/jd.jpg", UriKind.Absolute)) : null;
        //        //ImageSource image = null;
        //        //string text1 = "Lorem ipsum dolor sit amet integer fringilla, dui eget ultrices cursus, justo tellus.";
        //        //string text2 = "In ornare ante magna, eget volutpat mi bibendum a. Nam ut ullamcorper libero. Pellentesque habitant.";
        //        //string text3 = "Quisque sapien odio, mollis tincidunt est id, fringilla euismod neque. Aenean adipiscing lorem dui, nec. ";
        //        if (MyNotificationService == null) return;
        //        DevExpress.Mvvm.INotification notification = MyNotificationService.CreatePredefinedNotification(text1, text2, text3, image);
        //        notification.ShowAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}

        #endregion

        #region 抽象方法，实现类需实现
        public abstract bool CanExecute();
        public abstract void Execute();
        public abstract void ExecuteGeneric(string parameter);
        #endregion

        #region DelegateCommand
        private DelegateCommand _executeDelegateCommand;
        public DelegateCommand ExecuteDelegateCommand
        {
            get
            {
                if (_executeDelegateCommand == null)
                    _executeDelegateCommand = new DelegateCommand(Execute, CanExecute);
                return _executeDelegateCommand;
            }
            set
            {
                _executeDelegateCommand = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 普通信息类型提示框
        /// </summary>
        /// <param name="log1">第一行详细弹窗内容</param>
        /// <param name="log2">第二行详细弹窗内容</param>
        protected void NotificationInfoMsg(string log1, string log2 = null)
        {
            try
            {
                Log4Lib.LogHelper.WriteLog(this.Title, GlobalClass.InfoImage, log1, log2);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        /// <summary>
        /// 异常类型提示框
        /// </summary>
        /// <param name="log1">第一行详细弹窗内容</param>
        /// <param name="log2">第二行详细弹窗内容</param>
        /// <param name="ex">异常</param>
        protected void NotificationErrorMsg(string log1, string log2 = null, Exception ex=null)
        {
            try
            {
                if (ex == null)
                {
                    Log4Lib.LogHelper.WriteErrorLog(this.Title, GlobalClass.ErrorImage, log1, log2);
                }
                else
                {
                    Log4Lib.LogHelper.WriteLog(this.Title, GlobalClass.ErrorImage, ex);
                }
            }
            catch (Exception e)
            {
                Log4Lib.LogHelper.WriteLog(e.Message, e);
            }
        }
        /// <summary>
        /// 警告类型提示框
        /// </summary>
        /// <param name="log1">第一行详细弹窗内容</param>
        /// <param name="log2">第二行详细弹窗内容</param>
        protected void NotificationWarningMsg(string log1, string log2 = null)
        {
            try
            {
                Log4Lib.LogHelper.WriteLog(this.Title, GlobalClass.WarningImage, log1, log2);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        /// <summary>
        /// 问题类型提示框
        /// </summary>
        /// <param name="log1">第一行详细弹窗内容</param>
        /// <param name="log2">第二行详细弹窗内容</param>
        protected void NotificationQuestionMsg(string log1, string log2 = null)
        {
            try
            {
                Log4Lib.LogHelper.WriteLog(this.Title, GlobalClass.QuestionImage, log1, log2);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        #endregion

    }
}
