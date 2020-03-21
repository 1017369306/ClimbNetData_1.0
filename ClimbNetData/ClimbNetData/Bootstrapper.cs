using Prism.Mef;
using Prism.Modularity;
using System;
using System.Windows;
using Prism.Ioc;
using Prism;
using System.ComponentModel.Composition.Hosting;
using Prism.Unity;

namespace ClimbNetData
{
    public class BootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            //配置module模块，会调用模块的Initialize方法
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(BootStrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ChooseModule.ChooseClimbModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(PrismUICommon.View.UserControl1).Assembly));

            //moduleCatalog.AddModule(typeof(ChooseModule.ChooseClimbModule));
            //moduleCatalog.AddModule(typeof(HelloWorldModule.DebugModule));
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            // When using MEF, the existing Prism ModuleCatalog is still the place to configure modules via configuration files.
            return new ConfigurationModuleCatalog();
        }

        protected override IContainerExtension CreateContainerExtension()
        {
            return this.ContainerExtension;
        }
    }
}
