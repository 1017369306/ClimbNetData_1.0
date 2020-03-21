using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
