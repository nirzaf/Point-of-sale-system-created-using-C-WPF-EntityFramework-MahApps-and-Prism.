using Microsoft.Practices.Unity;
using PoS.BL;
using PoS.BL.Service;
using PoS.Views;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PoS
{
	public class MainBootstrapper: UnityBootstrapper
	{
		/// <summary>
		/// Create Shell
		/// </summary>
		/// <returns>
		/// Prism Shell
		/// </returns>
		protected override DependencyObject CreateShell ()
		{
			Container.RegisterInstance (typeof (Window),
										"MainShell",
										Container.Resolve<MainShell> (),
										new ContainerControlledLifetimeManager ());
			return Container.Resolve<Window> ("MainShell");
		}

		protected override void InitializeShell ()
		{
			Mutex mutex = new Mutex(true, "PoS");

			if(mutex.WaitOne(0, false) == true) {
				var regionManager = this.Container.Resolve<IRegionManager>();

				if (regionManager != null) {
					regionManager.RegisterViewWithRegion ("MainRegion", typeof (HomeTilesView));
					regionManager.RegisterViewWithRegion ("MainRegion", typeof (InventoryMainView));
					regionManager.RegisterViewWithRegion ("LeftCommandRegion", typeof (HomeCommandView));
					regionManager.RegisterViewWithRegion ("RightCommandRegion", typeof (LoginCommandView));
					regionManager.RegisterViewWithRegion ("FlyoutControlRegion", typeof (LoginFlyOutView));
					regionManager.RegisterViewWithRegion ("FlyoutControlRegion", typeof (UserInfoFlyoutView));
				}

				App.Current.MainWindow.Show ();
			}
			else {
				App.Current.Shutdown ();
			}

			mutex.ReleaseMutex ();
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
			ISecurityService securityService = TServiceFactory.GetSecurityService();
			Container.RegisterInstance(securityService);
			Container.RegisterInstance (Container);

			Container.RegisterTypeForNavigation<HomeTilesView> ("HomeTilesView");
			Container.RegisterTypeForNavigation<InventoryMainView> ("InventoryMainView");

			var regionManager = this.Container.Resolve<IRegionManager>();
		}
	}
}
