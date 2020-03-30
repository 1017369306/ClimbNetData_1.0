using System.Windows.Controls;
using System.Windows.Input;

namespace PrismUICommon.Views
{
    /// <summary>
    /// SearchTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchTextBox : UserControl
    {
        //private readonly IRegionManager _regionManager;
        //private readonly IUnityContainer _unityContainer;
        private string _btnToolTip = "搜索";

        public string BtnToolTip { get => _btnToolTip; set => _btnToolTip = value; }

        public SearchTextBox()
        {
            InitializeComponent();
            this.BtnSearch.MouseLeftButtonUp += BtnSearch_MouseLeftButtonUp;
        }
        public void DisplayHelloWorldView()
        {
            //var view = this._regionManager.Regions[RegionNames.ContentRegion].GetView(RegionNames.SearchText) as DependencyObject;
            //IRegion region = RegionManager.GetRegionManager(view).Regions[RegionNames.SearchText];
            //region.Add(new SearchTextBox(), "hello");
        }

        private void BtnSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            //if (!e.Handled)
            //{
            //    if ((this.moduleTrackingState != null) && (this.moduleTrackingState.ExpectedInitializationMode == InitializationMode.OnDemand) && (moduleTrackingState.ModuleInitializationStatus == ModuleInitializationStatus.NotStarted))
            //    {
            //        this.RaiseRequestModuleLoad();
            //        e.Handled = true;
            //    }
            //}
        }
    }
}
