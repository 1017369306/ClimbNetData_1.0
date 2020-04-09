using HR.Share.PublicShare;
using HR.Share.PublicShare.BaseClass;
using HR.Share.PublicShare.BaseClass.AbstractClass;
using HR.Share.PublicShare.BaseClass.Interface;
using HR.Share.PublicShare.Event;
using Maticsoft.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using PrismUICommon.Views;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Unity;

namespace HomePage.ViewModels
{
    /// <summary>
    /// MyINavigationAware
    /// </summary>
    public class HomePageViewModel : ViewModelBase, INavigationAware
    {
        #region 私有属性
        private bool _canNavigation = false;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        IRegionNavigationJournal _journal;
        private IEventAggregator _ea;
        private object[] _params;

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
        public object[] Params
        {
            get => _params; set
            {
                _params = value;
            }
        }
        #endregion

        private DelegateCommand _webSiteCommand;
        public DelegateCommand WebSiteCommand
        {
            get
            {
                //if (_webSiteCommand == null)
                //    _webSiteCommand = new DelegateCommand(WebSiteClick);
                return _webSiteCommand;
            }
        }
        public DelegateCommand MoreModelsCommand
        {
            get
            {
                return new DelegateCommand(MoreModelsClick);
            }
        }

        private void MoreModelsClick()
        {
            try
            {
                IRegion ContentRegion = this._regionManager.Regions[RegionNames.ContentRegion];
                object obj = this._regionManager.Regions[RegionNames.ContentRegion].GetView(ViewNames.ChooseModel);
                if (obj == null)
                {
                    //Views.ChooseModel chooseModel = new Views.ChooseModel();
                    //IRegionManager ChooseModelRegionManager = ContentRegion.RegionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.ChooseModel));
                    //IRegion Region1 = this._regionManager.Regions[RegionNames.ChooseModelRegion];
                    object chooseModel1 = ContentRegion.GetView(ViewNames.ChooseModel1);
                    if (chooseModel1 == null)
                    {
                        string Content = MainBaseMethod.GetEnumDescription(GlobalClass.MenuItems.ClimbData);
                        object objModel = MainBaseMethod.GetModule(Content, Params);
                        if (objModel == null)
                        {
                            Log4Lib.LogHelper.WriteErrorLog(Content + "模块加载异常！");
                            return;
                        }
                        IModuleBase imoduleBase = (IModuleBase)objModel;
                        imoduleBase.Load();
                        //ContentRegion.Add(this._unityContainer.Resolve<Views.ChooseModel1>(), ViewNames.ChooseModel1, true);
                    }
                    else
                    {
                        ContentRegion.Activate(chooseModel1);
                    }
                    //ShowOrdersView();

                    //IRegionManager ChooseModelRegionManager = this._regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(Views.ChooseModel));
                    //Views.ChooseModel1 chooseModel1 = new Views.ChooseModel1();
                    //IRegionManager ChooseModel1RegionManager = ChooseModelRegionManager.Regions[RegionNames.ChooseModelRegion].Add(chooseModel1, ViewNames.ChooseModel1, true);
                    //WebSiteTypeAndSort webSiteTypeAndSort = new WebSiteTypeAndSort();
                    //ChooseModel1RegionManager.Regions[RegionNames.WebSiteTypeAndSort].Add(webSiteTypeAndSort, RegionNames.WebSiteTypeAndSort, true);
                    //IRegionManager detailsRegionManager = ContentRegion.Add(chooseModel, RegionNames.ChooseModelRegion, true);
                    //detailsRegionManager.Regions[RegionNames.ChooseModelRegion].Add(new Views.ChooseModel1());
                    //ContentRegion.Activate(chooseModel);
                }
                else
                {
                    ContentRegion.Activate(obj);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void ShowOrdersView()
        {
            IRegion region = this._regionManager.Regions[RegionNames.ChooseModelRegion];

            object ordersView = region.GetView(ViewNames.ChooseModel1);
            if (ordersView != null)
            {
                region.Activate(ordersView);
            }
        }

        public DelegateCommand GoForwardCommand { get; set; }
        /// <summary>
        /// 网站按钮点击事件
        /// </summary>
        private void WebSiteClick(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                websitebase websitebaseTemp = (websitebase)button.Tag;
                var parameters = new NavigationParameters();
                parameters.Add("websitebase", websitebaseTemp);

                if (websitebaseTemp != null)
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, "ChooseModel1", parameters);
            }
            catch (Exception ex)
            {
                this.NotificationErrorMsg(ex.Message, null, ex);
            }
        }

        #region 初始化
        public HomePageViewModel(IRegionManager regionManager, IUnityContainer unityContainer, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
            _ea = ea;
            this.Title = "首页";
            this.CanClose = false;
            this.CanTogglePin = false;
            this.CanMove = false;
            GoForwardCommand = new DelegateCommand(GoForward, CanGoForward);
            Params = new object[] { _regionManager, _unityContainer };

            //MessageDictionaryBase messageDictionaryBase = new MessageDictionaryBase();
            //messageDictionaryBase.Key = MessageNames.Notification;
            //messageDictionaryBase.Value = new List<string> { "首页", "加载成功！", String.Format("Time: {0}", DateTime.Now) };
            //_ea.GetEvent<MessageDictionarySentEvent>().Publish(messageDictionaryBase);
            //ConfigureRegionManager();
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

        /// <summary>
        /// 当前的页面被导航到以后发生，这个函数可以用来处理URI的参数。
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// 当从其它页面导航至本页面的时候，首先会调用IsNavigationTarget。这个方法的作用就是告诉Prism，是重复使用这个视图的实例还是再创建一个。然后调用OnNavigatedTo方法
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 当从本页面转到其它页面的时候，会调用OnNavigatedFrom方法
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //CanNavigation = false;
        }
        #endregion

        #region 事件
        private void GoForward()
        {
            _journal.GoForward();
        }

        private bool CanGoForward()
        {
            return _journal != null && _journal.CanGoForward;
        }

        //private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {

        //        Label label = (Label)sender;//FF3C55C5 #FFFFFFFF
        //        UIElementCollection collection = this.ModuleTypes.Children;
        //        foreach (System.Windows.Controls.Control item in collection)
        //        {
        //            if (item == label)
        //            {
        //                item.Background = (Brush)this.FindResource("LabelForeground1");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground3");
        //            }
        //            else
        //            {
        //                item.Background = (Brush)this.FindResource("Transparent");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground2");
        //            }
        //        }
        //        //label.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF3C55C5"));
        //        //label.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}

        //private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        Label label = (Label)sender;//FF3C55C5 #FFFFFFFF
        //        UIElementCollection collection = this.ModuleSort.Children;
        //        foreach (System.Windows.Controls.Control item in collection)
        //        {
        //            if (item == label)
        //            {
        //                item.Background = (Brush)this.FindResource("LabelForeground1");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground3");
        //            }
        //            else
        //            {
        //                item.Background = (Brush)this.FindResource("Transparent");
        //                item.Foreground = (Brush)this.FindResource("LabelForeground2");
        //            }
        //        }
        //        //label.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF3C55C5"));
        //        //label.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log4Lib.LogHelper.WriteLog(ex.Message, ex);
        //    }
        //}
        #endregion

    }
}
