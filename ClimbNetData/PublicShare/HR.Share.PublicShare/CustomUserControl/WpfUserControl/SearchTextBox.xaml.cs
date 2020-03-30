using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HR.Share.PublicShare.CustomUserControl.WpfUserControl
{
    /// <summary>
    /// SearchTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchTextBox : UserControl
    {
        public SearchTextBox()
        {
            InitializeComponent();
        }
        public event EventHandler<SearchEventArgs> OnSearch;
        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            ExeccuteSearch();
        }

        private void TbxInput_OnKeyDown(object sender, KeyEventArgs e)
        {
            ExeccuteSearch();
        }

        private void ExeccuteSearch()
        {
            if (OnSearch != null)
            {
                var args = new SearchEventArgs();
                args.SearchText = TbxInput.Text;
                OnSearch(this, args);
            }
        }
    }

    public class SearchEventArgs : EventArgs
    {
        public string SearchText { get; set; }
    }
}
