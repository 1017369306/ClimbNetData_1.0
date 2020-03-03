using HR.Share.PublicShare.StaticBase.ClimbData;
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
    /// WebSiteTypeAndSort.xaml 的交互逻辑
    /// </summary>
    public partial class WebSiteTypeAndSort : UserControl
    {
        public WebSiteTypeAndSort()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                #region 生成模板类型
                List<GlobalStatic.WebSiteType> webSiteTypes = MainBaseMethod.foreachEnum<GlobalStatic.WebSiteType>();
                this.ModuleTypes.Children.Clear();
                foreach (GlobalStatic.WebSiteType item in webSiteTypes)
                {
                    Label label = new Label();
                    label.Content = MainBaseMethod.GetEnumDescription(item);
                    label.Margin = new System.Windows.Thickness(5, 0, 0, 0);
                    label.Padding = new System.Windows.Thickness(5, 0, 5, 0);
                    label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    label.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    label.PreviewMouseLeftButtonDown += Label_PreviewMouseLeftButtonDown;
                    this.ModuleTypes.Children.Add(label);
                }
                #endregion

                #region 生成模板排序
                List<GlobalStatic.SortType> sortTypes = MainBaseMethod.foreachEnum<GlobalStatic.SortType>();
                this.ModuleSort.Children.Clear();
                foreach (GlobalStatic.SortType item in sortTypes)
                {
                    Label label = new Label();
                    label.Content = MainBaseMethod.GetEnumDescription(item);
                    //label.Margin = new System.Windows.Thickness(5, 0, 0, 0);
                    label.Padding = new System.Windows.Thickness(5, 0, 5, 0);
                    label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    label.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    this.ModuleSort.Children.Add(label);
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
        }

        private void Label_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
