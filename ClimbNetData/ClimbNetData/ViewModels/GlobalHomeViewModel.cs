using DevExpress.Mvvm.DataAnnotations;
using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Unity;

namespace ClimbNetData.ViewModels
{
    public class GlobalHomeViewModel:ViewModelBase
    {
        #region 变量
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        private System.Windows.Window _globalHome = null;
        private IEventAggregator _ea;
        private string _title = "墨鱼";
        public virtual bool ShowImage { get; set; }

        #endregion

        #region DelegateCommand

        private DelegateCommand<System.Windows.Window> _globalHomeLoadedCommand;
        public DelegateCommand<System.Windows.Window> GlobalHomeLoadedCommand
        {
            get
            {
                if (_globalHomeLoadedCommand == null)
                    _globalHomeLoadedCommand = new DelegateCommand<System.Windows.Window>(GlobalHomeLoaded);
                return _globalHomeLoadedCommand;
            }
        }

        #endregion

        #region 初始化
        private void GlobalHomeLoaded(Window obj)
        {
            try
            {
                this._globalHome = obj;
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        public GlobalHomeViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            _ea = ea;
            //this.Title = _title;
            ShowImage = true;
            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
            _ea.GetEvent<MessageDictionarySentEvent>().Subscribe(MessageDictionaryReceived);
        }
        #endregion

        #region 事件

        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="obj"></param>
        private void MessageDictionaryReceived(MessageDictionaryBase obj)
        {
            try
            {
                if (obj.Key.Equals(MessageNames.Notification))
                {
                    List<string> MessageList = (List<string>)obj.Value;
                    //ShowNotification(MessageList[0], MessageList[1], MessageList[2], obj.Image);
                }
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 接受消息并进行处理（主要是涉及到主窗体的事件）
        /// </summary>
        /// <param name="obj"></param>
        private void MessageReceived(string obj)
        {
            try
            {
                if (obj.Equals(MessageNames.DragMove))
                {
                    _globalHome.DragMove();
                }
                else if (obj.Equals(MessageNames.WindowStateChanged))
                {
                    _globalHome.WindowState = _globalHome.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                }
                else if (obj.Equals(MessageNames.MinWindows))
                {
                    _globalHome.WindowState = WindowState.Minimized;
                }
                else if (obj.Equals(MessageNames.MaxWindows))
                {
                    if (_globalHome.WindowState == WindowState.Maximized)
                    {
                        _globalHome.WindowState = WindowState.Normal;//设置窗口还原
                        _globalHome.WindowStyle = WindowStyle.None;
                    }
                    else
                    {
                        _globalHome.WindowState = WindowState.Maximized;//设置窗口最大化
                    }
                }
                else if (obj.Equals(MessageNames.Notification))
                {

                }
                else if (obj.Equals(MessageNames.CloseWindows))
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        public void ConfigureRegionManager()
        {
            try
            {
                //Inject views in regions
                _regionManager.Regions[RegionNames.GlobalRegion].Add(_unityContainer.Resolve<Views.MainWindow>());
                _regionManager.Regions[RegionNames.MenuRegion].Add(_unityContainer.Resolve<Views.MenuExpander>());

                //添加首页
                //IRegion detailsRegion = _regionManager.Regions[RegionNames.ContentRegion];
                //IRegionManager detailsRegionManager = detailsRegion.Add(_unityContainer.Resolve<HomePage.Views.HomePage>(), null, true);
                //detailsRegion.RegionManager = detailsRegionManager;
                //detailsRegion.Activate(homePage);

                //IRegion detailsRegion = this._regionManager.Regions[RegionNames.ContentRegion];
                //HomePage.Views.HomePage view = new HomePage.Views.HomePage();
                //bool createRegionManagerScope = true;
                //IRegionManager detailsRegionManager = detailsRegion.Add(view, null,
                //                            createRegionManagerScope);
                //detailsRegionManager.Regions[RegionNames.SearchText].Add(new PrismUICommon.Views.SearchTextBox());
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MainBaseMethod.StopTimer();//停止定时器
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
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
