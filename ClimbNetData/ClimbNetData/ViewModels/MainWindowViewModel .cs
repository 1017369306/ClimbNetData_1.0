using HR.Share.PublicShare;
using Prism.Mvvm;
using Prism.Regions;
using PrismUICommon.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using HomePage;
using Xceed.Wpf.AvalonDock.Layout;
using Prism.Commands;

namespace ClimbNetData.ViewModels
{
    public class MainWindowViewModel : CustomICommand
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        private string _logInfo = "加载成功！";
        private DateTime _nowDateTime = DateTime.Now;
        private string _ClientTitle = "墨鱼";

        public string ClientTitle
        {
            get
            {
                return _ClientTitle;
            }

            set
            {
                SetProperty(ref _ClientTitle, value);
            }
        }
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

        private DelegateCommand<LayoutDocumentPane> LayoutDocumentPaneChangedCommand; //申明委托

        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            LayoutDocumentPaneChangedCommand = new DelegateCommand<LayoutDocumentPane>(DocPane1_ChildrenCollectionChanged); //实例化
            Init();
            //ConfigureRegionManager();
        }

        private void DocPane1_ChildrenCollectionChanged(LayoutDocumentPane layoutDocumentPane)
        {
            if (layoutDocumentPane == null || layoutDocumentPane.Children.Count == 0) return;
            foreach (LayoutDocument item in layoutDocumentPane.Children)
            {
                if (item.Title == "首页")
                {
                    item.CanClose = false;
                    item.IsActive = true;
                    return;
                }
            }
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
    }
}
