using Prism.Regions;
using Xceed.Wpf.AvalonDock.Layout;

namespace PrismUICommon.CustomRegionAdapter
{
    /// <summary>
    /// StackPanel适配器类型 （用于注册类型和适配器之间的映射。prism原来只有在itemscontrol、selector和contentcontrol这三个实现了prism:RegionManager.RegionName=""可以把模块加载到控件）
    /// </summary>
    public class LayoutDocumentPaneRegionAdapter : RegionAdapterBase<LayoutDocumentPane>
    {
        public LayoutDocumentPaneRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, LayoutDocumentPane regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (LayoutDocument element in e.NewItems)
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
