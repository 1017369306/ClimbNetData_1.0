using Prism.Regions;

namespace PrismUICommon.Interface
{
    public interface MyINavigationAware : INavigationAware
    {
        /// <summary>
        /// 能否导航标志
        /// </summary>
        bool CanNavigation { get; set; }
    }
}
