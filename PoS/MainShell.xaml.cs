using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PoS
{
	/// <summary>
	/// Interaction logic for MainShell.xaml
	/// </summary>
	public partial class MainShell : MetroWindow
	{
		IRegionManager mRegionManager;
		public MainShell (IRegionManager regionManager)
		{
			InitializeComponent ();

			mRegionManager = regionManager;

			if(mRegionManager != null) {
			}
		}

		/// <summary>
		/// Set Region Manager
		/// </summary>
		/// <param name="regionManager">[in] Region Manager</param>
		/// <param name="regionTarget">[in] Region Target</param>
		/// <param name="regionName">[in] Region Name</param>
		private void SetRegionManager (IRegionManager regionManager,
									   DependencyObject regionTarget,
									   string regionName)
		{
			RegionManager.SetRegionName (regionTarget, regionName);
			RegionManager.SetRegionManager (regionTarget, regionManager);
		}
	}
}
