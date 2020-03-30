using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using Unity;
using Xceed.Wpf.AvalonDock.Layout;

namespace ClimbNetData.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 变量
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        IEventAggregator _ea;
        private string _logInfo = "加载成功！";
        private DateTime _nowDateTime = DateTime.Now;

        public string LogInfo
        {
            get
            {
                return _logInfo;
            }

            set
            {
                SetProperty(ref _logInfo, value);
            }
        }
        /// <summary>
        /// 实时刷新当前时间
        /// </summary>
        public DateTime NowDateTime
        {
            get
            {
                return _nowDateTime;
            }
            set
            {
                SetProperty(ref _nowDateTime, value);
            }
        }
        #endregion

        #region Command
        private DelegateCommand<StackPanel> _titleLoadedCommand;
        private DelegateCommand _minBtnCommand;
        private DelegateCommand _maxBtnCommand;
        private DelegateCommand _CloseBtnCommand;

        public DelegateCommand<StackPanel> TitleLoadedCommand
        {
            get
            {
                if (_titleLoadedCommand == null)
                    _titleLoadedCommand = new DelegateCommand<StackPanel>(StackPanel_Load);
                return _titleLoadedCommand;
            }
        }
        public DelegateCommand MinBtnCommand
        {
            get
            {
                if (_minBtnCommand == null)
                    _minBtnCommand = new DelegateCommand(MinBtn_Click);
                return _minBtnCommand;
            }
        }

        private void MinBtn_Click()
        {
            try
            {
                _ea.GetEvent<MessageSentEvent>().Publish(MessageNames.MinWindows);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        public DelegateCommand MaxBtnCommand
        {
            get
            {
                if (_maxBtnCommand == null)
                    _maxBtnCommand = new DelegateCommand(MaxBtn_Click);
                return _maxBtnCommand;
            }
        }

        private void MaxBtn_Click()
        {
            try
            {
                _ea.GetEvent<MessageSentEvent>().Publish(MessageNames.MaxWindows);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        public DelegateCommand CloseBtnCommand
        {
            get
            {
                if (_CloseBtnCommand == null)
                    _CloseBtnCommand = new DelegateCommand(CloseBtn_Click);
                return _CloseBtnCommand;
            }
        }

        private void CloseBtn_Click()
        {
            try
            {
                _ea.GetEvent<MessageSentEvent>().Publish(MessageNames.CloseWindows);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        #endregion

        #region 初始化
        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            _ea = ea;
            Init();
            this.NotificationInfoMsg("启动成功！");
        }
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Init()
        {
            try
            {
                MainBaseMethod.pushTimerDateTime += RefushDateTime;
                MainBaseMethod.InitTimer();
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
        #endregion

        #region 事件
        private void StackPanel_Load(StackPanel obj)
        {
            try
            {
                obj.MouseMove += StackPanel_MouseMove;
                obj.MouseDown += StackPanel_MouseDown;
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 拖动窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _ea.GetEvent<MessageSentEvent>().Publish(MessageNames.DragMove);

                //this.DragMove();
            }
        }

        int i = 0;
        /// <summary>
        /// 双击改变主窗体的状态（最大化、普通）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, el) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;
            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                _ea.GetEvent<MessageSentEvent>().Publish(MessageNames.WindowStateChanged);
            }
        }
        /// <summary>
        /// 刷新时间
        /// </summary>
        /// <param name="dateTime"></param>
        private void RefushDateTime(DateTime dateTime)
        {
            try
            {
                NowDateTime = dateTime;
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }


        #endregion

        #region override
        private bool CanExecute(Label arg)
        {
            return true;
        }

        private bool CanExecute(LayoutDocumentPane arg)
        {
            return true;
        }
        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {

        }

        public override void ExecuteGeneric(string parameter)
        {

        }
        #endregion
    }
}
