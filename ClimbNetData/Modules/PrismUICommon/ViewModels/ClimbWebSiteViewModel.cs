using Prism.Modularity;
//using Prism.Mef.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using Prism.Ioc;
using System.Windows;
using Maticsoft.Model;
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using HR.Share.PublicShare.BindingData;
using System.Windows.Data;
using PrismUICommon.BaseClass;

namespace PrismUICommon.ViewModels
{
    public class ClimbWebSiteViewModel : CustomICommand, INavigationAware
    {
        #region 私有属性
        private bool _canNavigation = false;
        //private WebSitesData _webSitesData = null;
        #endregion

        #region 公有属性
        /// <summary>
        /// 数据list，绑定时应转为ObservableCollection
        /// </summary>
        public ICollectionView Customers { get; private set; }
        public bool CanNavigation
        {
            get { return _canNavigation; }
            set
            {
                _canNavigation = value;
            }
        }
        #endregion
        public ClimbWebSiteViewModel()
        {

        }

        public ClimbWebSiteViewModel(ObservableCollection<WebSitesData> customers)
        {
            Customers = new ListCollectionView(customers);
            Customers.CurrentChanged += SelectedItemChanged;
            //this.ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);
        }

        private void SelectedItemChanged(object sender, EventArgs e)
        {
            WebSitesData current = Customers.CurrentItem as WebSitesData;
            //deal 集合过滤、排序、分组、以及选中项的跟踪和更改的属性和方法
            //...
            //...

            //当用户从UI选择了一个customer时，View Model将得到通知调用与当前选择customer相关的命令。View Model也可以编程调用collection view中的方法来改变UI中选中的项：
            Customers.MoveCurrentToNext();
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

        /// <summary>
        /// 网站模板点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWebSite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ModuleExportAttribute.GetCustomAttribute()

                //_websitebase = View.ClimbWebSite as websitebase;
                //根据ID查询其子模板

                websitebase websitebaseNext = new websitebase();
                //websitebaseNext.content = "京东" + i;
                //websitebaseNext.moduleCount = "共" + i + "个模板";
                websitebaseNext.imageUrl = new Uri(@"pack://application:,,,/PublicResources;component/Resources/Images/jd.jpg");
                //climbWebSite.DataContext = websitebaseNext;
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
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
    }
}
