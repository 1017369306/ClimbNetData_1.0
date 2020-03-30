using HR.Share.PublicShare.StaticBase.ClimbData;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HR.Share.PublicShare.CustomUserControl.WpfUserControl
{
    /// <summary>
    /// WebSiteTypeAndSort.xaml 的交互逻辑
    /// </summary>
    public partial class WebSiteTypeAndSort : UserControl
    {

        #region 变量


        #endregion

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
                    label.Height = ModuleTypes.ActualHeight;
                    label.Content = MainBaseMethod.GetEnumDescription(item);
                    label.Margin = new System.Windows.Thickness(5, 0, 0, 0);
                    label.Padding = new System.Windows.Thickness(5, 0, 5, 0);
                    label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                    //label.PreviewMouseLeftButtonDown += Label_PreviewMouseLeftButtonDown;
                    label.MouseLeftButtonDown += Label_MouseLeftButtonDown;
                    label.Style = (Style)this.FindResource("LabelStyle1");
                    this.ModuleTypes.Children.Add(label);
                }
                #endregion

                #region 生成模板排序
                List<GlobalStatic.SortType> sortTypes = MainBaseMethod.foreachEnum<GlobalStatic.SortType>();
                this.ModuleSort.Children.Clear();
                foreach (GlobalStatic.SortType item in sortTypes)
                {
                    Label label = new Label();
                    label.Height = ModuleSort.ActualHeight;
                    label.Content = MainBaseMethod.GetEnumDescription(item);
                    //label.Margin = new System.Windows.Thickness(5, 0, 0, 0);
                    label.Padding = new System.Windows.Thickness(5, 0, 5, 0);
                    label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                    label.MouseLeftButtonDown += Label1_MouseLeftButtonDown;
                    label.Style = (Style)this.FindResource("LabelStyle1");
                    this.ModuleSort.Children.Add(label);
                }
                #endregion

                //默认点击第一个label
                if (this.ModuleTypes.Children.Count > 0)
                {
                    Label label1 = this.ModuleTypes.Children[0] as Label;
                    Label_MouseLeftButtonDown(label1, null);
                }
                if (this.ModuleSort.Children.Count > 0)
                {
                    Label label1 = this.ModuleSort.Children[0] as Label;
                    Label1_MouseLeftButtonDown(label1, null);
                }
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label label = (Label)sender;//FF3C55C5 #FFFFFFFF
                UIElementCollection collection = this.ModuleTypes.Children;
                foreach (System.Windows.Controls.Control item in collection)
                {
                    if (item == label)
                    {
                        item.Background = (Brush)this.FindResource("LabelForeground1");
                        item.Foreground = (Brush)this.FindResource("LabelForeground3");
                    }
                    else
                    {
                        item.Background = (Brush)this.FindResource("Transparent");
                        item.Foreground = (Brush)this.FindResource("LabelForeground2");
                    }
                }
                //label.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF3C55C5"));
                //label.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF"));
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label label = (Label)sender;//FF3C55C5 #FFFFFFFF
                UIElementCollection collection = this.ModuleSort.Children;
                foreach (System.Windows.Controls.Control item in collection)
                {
                    if (item == label)
                    {
                        item.Background = (Brush)this.FindResource("LabelForeground1");
                        item.Foreground = (Brush)this.FindResource("LabelForeground3");
                    }
                    else
                    {
                        item.Background = (Brush)this.FindResource("Transparent");
                        item.Foreground = (Brush)this.FindResource("LabelForeground2");
                    }
                }
                //label.Background= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF3C55C5"));
                //label.Foreground= new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFFFFFFF"));
            }
            catch (Exception ex)
            {
                Log4Lib.LogHelper.WriteLog(ex.Message, ex);
            }
        }
    }
}
