using HR.Share.PublicShare.BaseClass;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HR.Share.PublicShare.ViewModule
{
    public class MyViewModel : BindableBase
    {
        /// <summary>
        /// 数据list，绑定时应转为ObservableCollection
        /// </summary>
        public ICollectionView Customers { get; private set; }
        public MyViewModel(ObservableCollection<UavData> customers)
        {
            Customers = new ListCollectionView(customers);
            Customers.CurrentChanged += SelectedItemChanged;
        }
        private void SelectedItemChanged(object sender, EventArgs e)
        {
            UavData current = Customers.CurrentItem as UavData;
            //deal 集合过滤、排序、分组、以及选中项的跟踪和更改的属性和方法
            //...
            //...

            //当用户从UI选择了一个customer时，View Model将得到通知调用与当前选择customer相关的命令。View Model也可以编程调用collection view中的方法来改变UI中选中的项：
            Customers.MoveCurrentToNext();
        }
    }
}
