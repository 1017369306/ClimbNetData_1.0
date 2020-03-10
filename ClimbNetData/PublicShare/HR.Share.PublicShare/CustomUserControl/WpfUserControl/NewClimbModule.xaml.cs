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

namespace HR.Share.PublicShare.CustomUserControl.WpfUserControl
{
    /// <summary>
    /// NewClimbModule.xaml 的交互逻辑
    /// </summary>
    public partial class NewClimbModule : UserControl
    {
        public NewClimbModule()
        {
            InitializeComponent();
        }

        private void PromoteList_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PromoteList.RowDefinitions.Clear();
                int num = 10;
                for (int i = 0; i < num; i++)
                {
                    RowDefinition rowTemp = new RowDefinition();
                    rowTemp.Height = GridLength.Auto;
                    PromoteList.RowDefinitions.Add(rowTemp);
                }
                //PromoteList.ShowGridLines = true;
                for (int i = 0; i < num; i++)
                {
                    WrapPanel wrapPanel = new WrapPanel();

                    Label label1 = new Label();
                    label1.Content = i + 1;
                    label1.Margin = new Thickness(0, 0, 10, 0);
                    label1.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF124897"));

                    Label label2 = new Label();
                    label2.Content = "拼多多-商城";
                    label2.Style = (Style)this.FindResource("LabelStyle2");
                    //label2.Margin = new Thickness(0, 0, 10, 0);
                    //label2.Foreground = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF124897"));

                    wrapPanel.Children.Add(label1);
                    wrapPanel.Children.Add(label2);

                    PromoteList.Children.Add(wrapPanel);
                    Grid.SetRow(wrapPanel, i);
                    //Grid.SetColumn(wrapPanel, 1);
                }

            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
    }
}
