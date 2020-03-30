using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using HR.Share.PublicShare.Event;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using Unity;

namespace MyTask.ViewModels
{
    public class MyTaskHomePageViewModel : ViewModelBase
    {

        #region 私有属性
        private bool _canNavigation = false;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        private IEventAggregator _ea;

        #endregion
        #region 公有属性
        public bool CanNavigation
        {
            get { return _canNavigation; }
            set
            {
                _canNavigation = value;
            }
        }

        #endregion
        #region 初始化
        public MyTaskHomePageViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            _ea = ea;
            this.Title = "我的任务";
            this.CanClose = true;
            this.CanMove = false;
            Log4Lib.LogHelper.WriteLog("测试");

            this.NotificationInfoMsg("加载成功！");

            //MessageDictionaryBase messageDictionaryBase = new MessageDictionaryBase();
            //messageDictionaryBase.Key = MessageNames.Notification;
            //messageDictionaryBase.Value = new List<string> { "我的任务", "加载成功！", String.Format("Time: {0}", DateTime.Now) };
            //_ea.GetEvent<MessageDictionarySentEvent>().Publish(messageDictionaryBase);
        }

        #endregion

        #region 实现接口和抽象类
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
