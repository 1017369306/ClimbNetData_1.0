using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using Prism.Regions;
using PrismUICommon.Interface;
using PrismUICommon.UsingCompositeCommands.Core;
using System;

namespace PrismUICommon.ViewModels
{
    public class ChooseClimbModuleViewModel : ViewModelBase, MyINavigationAware
    {
        #region 私有属性
        private bool _canNavigation = false;
        private IApplicationCommands _applicationCommands;

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
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommands; }
            set { SetProperty(ref _applicationCommands, value); }
        }
        #endregion
        #region 初始化
        //public ChooseClimbModuleViewModule()
        //{

        //}
        public ChooseClimbModuleViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
        #endregion
        #region 实现接口和抽象类
        public override bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteGeneric(string parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当实现被导航到时的事件
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            CanNavigation = true;
        }

        /// <summary>
        /// 以确定此实例是否可以处理导航请求
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return CanNavigation;
        }

        /// <summary>
        /// 当实现者被导航离开时调用。
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            CanNavigation = false;
        }
        #endregion
    }
}
