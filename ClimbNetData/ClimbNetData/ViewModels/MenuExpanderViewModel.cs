using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using HR.Share.PublicShare.BaseClass.Interface;
using HR.Share.PublicShare.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Unity;

namespace ClimbNetData.ViewModels
{
    public class MenuExpanderViewModel : ViewModelBase
    {
        #region 变量
        IRegionManager _regionManager;
        IUnityContainer _unityContainer;
        private object[] _params;
        private IEventAggregator _ea;

        public object[] Params
        {
            get => _params; set
            {
                _params = value;
            }
        }
        #endregion

        #region DelegateCommand
        public DelegateCommand<Button> MenuCommand { get; set; }

        public DelegateCommand<Grid> MenuItemsLoadedCommand { get { return new DelegateCommand<Grid>(MenuItemsLoaded); } }
        public DelegateCommand ShowPredefinedCommand
        {
            get
            {
                return new DelegateCommand(ShowPredefined);
            }
        }

        private void ShowPredefined()
        {
            try
            {
                Log4Lib.LogHelper.WriteLog("测试");

                //this.ShowNotification("菜单", "加载成功", String.Format("Time: {0}", DateTime.Now), null);

                //MessageDictionaryBase messageDictionaryBase = new MessageDictionaryBase();
                //messageDictionaryBase.Key = MessageNames.Notification;
                //messageDictionaryBase.Value = new List<string> { "菜单", "加载成功！", String.Format("Time: {0}", DateTime.Now) };
                //_ea.GetEvent<MessageDictionarySentEvent>().Publish(messageDictionaryBase);
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }


        #endregion

        #region 初始化
        public MenuExpanderViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            _ea = ea;
            Params = new object[] { _regionManager, _unityContainer };
            MenuCommand = new DelegateCommand<Button>(MenuClick, CanClickMenu);
        }
        #endregion

        #region 事件
        /// <summary>
        /// 加载菜单项
        /// </summary>
        /// <param name="grid"></param>
        private void MenuItemsLoaded(Grid grid)
        {
            try
            {
                return;
                List<GlobalClass.MenuItems> menuItems = MainBaseMethod.foreachEnum<GlobalClass.MenuItems>();
                int menuCount = menuItems.Count;
                RowDefinitionCollection rowDefinitions = grid.RowDefinitions;
                for (int i = 0; i < menuCount; i++)
                {
                    RowDefinition newRow = new RowDefinition();
                    newRow.Height = new System.Windows.GridLength(40);
                    rowDefinitions.Add(newRow);
                }
                for (int i = 0; i < menuItems.Count; i++)
                {
                    Button button = new Button();
                    button.Content = MainBaseMethod.GetEnumDescription(menuItems[i]);
                    button.Style = (System.Windows.Style)System.Windows.Application.Current.FindResource("MenuBtn");
                    grid.Children.Add(button);
                    //设置行号
                    Grid.SetRow(button, i + 1);
                }
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        private void MenuClick(Button button)
        {
            try
            {
                object obj = MainBaseMethod.GetModule(button.Content.ToString(), Params);
                if (obj == null)
                {
                    Log4Lib.LogHelper.WriteErrorLog("模块加载异常！");
                    return;
                }
                IModuleBase imoduleBase = (IModuleBase)obj;
                imoduleBase.Load();

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

            //HomePage.Views.HomePage homePage = new HomePage.Views.HomePage();
            ////Show a View in a Scoped Region（重复打开相同的嵌套region页面时，需使用Scoped Region来添加）
            //IRegionManager detailsRegionManager = detailsRegion.Add(homePage, null, true);
            //IRegionManager newRegionManager = detailsRegion.RegionManager.CreateRegionManager();
            //newRegionManager = detailsRegionManager;
            //detailsRegion.Activate(homePage);


            //detailsRegion.RegionManager.AddToRegion(RegionNames.ContentRegion, homePage);

            //_regionManager.Regions[RegionNames.ContentRegion].Add(_unityContainer.Resolve<HomePage.Views.HomePage>());
        }
        public bool CanClickMenu(Button button)
        {
            return true;
        }


        #endregion

        #region override
        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void ExecuteGeneric(string parameter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
