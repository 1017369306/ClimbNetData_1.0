using Prism.Ioc;
using Prism.Modularity;
//using Prism.Mef.Modularity;
using Prism.Regions;

namespace ChooseModule
{
    //[ModuleExport("ChooseClimbViewModule", typeof(ChooseClimbViewModule))]
    public class ChooseClimbViewModule : IModule
    {
        //private readonly IRegionViewRegistry regionViewRegistry;
        //[ImportingConstructor]
        //public UserControl1(IRegionViewRegistry registry)
        //{
        //    this.regionViewRegistry = registry;
        //}

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ChooseClimbViewModule", typeof(ChooseClimbModule));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

    }
}
