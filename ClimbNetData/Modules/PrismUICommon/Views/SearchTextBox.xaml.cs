using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismUICommon.Views
{
    /// <summary>
    /// SearchTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchTextBox : UserControl
    {
        public SearchTextBox()
        {
            InitializeComponent();
            this.BtnSearch.MouseLeftButtonUp += BtnSearch_MouseLeftButtonUp;
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
