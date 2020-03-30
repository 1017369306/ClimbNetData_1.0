using Prism.Regions;
using PrismUICommon.BaseClass;
using PrismUICommon.Interface;
using PrismUICommon.UsingCompositeCommands.Core;
using System;
using System.Drawing;
using System.Windows;

namespace PrismUICommon.ViewModels
{
    public class Label1ViewModel : CustomICommand, MyINavigationAware
    {
        #region 私有属性
        private bool _canNavigation = false;
        private IApplicationCommands _applicationCommands;
        private string _content = "Prism Unity Application";
        private Brush _isClickForeground = null;
        private Brush _isClickBackground = null;
        private Brush _isNotClickForeground = null;
        private Brush _isNotClickBackground = null;

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
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
        public Brush IsClickForeground { get => _isClickForeground; set => _isClickForeground = value; }
        public Brush IsClickBackground { get => _isClickBackground; set => _isClickBackground = value; }
        public Brush IsNotClickForeground { get => _isNotClickForeground; set => _isNotClickForeground = value; }
        public Brush IsNotClickBackground { get => _isNotClickBackground; set => _isNotClickBackground = value; }

        #endregion
        #region 初始化
        //public ChooseClimbModuleViewModule()
        //{

        //}
        public Label1ViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
            IsClickBackground = (Brush)Application.Current.FindResource("LabelForeground1");
            IsClickForeground = (Brush)Application.Current.FindResource("LabelForeground3");
            IsNotClickBackground = (Brush)Application.Current.FindResource("Transparent");
            IsNotClickForeground = (Brush)Application.Current.FindResource("LabelForeground2");
        }
        #endregion
        #region 实现接口和抽象类
        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            MessageBox.Show("马上跳转", "测试", MessageBoxButton.OK, MessageBoxImage.Information);
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
