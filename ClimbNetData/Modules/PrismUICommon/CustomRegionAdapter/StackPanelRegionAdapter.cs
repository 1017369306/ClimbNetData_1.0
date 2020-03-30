using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace PrismUICommon.CustomRegionAdapter
{
    /// <summary>
    /// StackPanel适配器类型 （用于注册类型和适配器之间的映射。prism原来只有在itemscontrol、selector和contentcontrol这三个实现了prism:RegionManager.RegionName=""可以把模块加载到控件）
    /// </summary>
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Children.Add(element);
                    }
                }

                //handle remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
