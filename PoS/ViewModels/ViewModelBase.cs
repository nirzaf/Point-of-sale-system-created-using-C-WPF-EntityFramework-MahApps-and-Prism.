using MahApps.Metro.Controls;
using Microsoft.Practices.ServiceLocation;
using PoS.BL.Service;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class ViewModelBase: BindableBase, INotifyPropertyChanged
	{
		#region Property
		private bool _isEnabled;
		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				if (_isEnabled != value) {
					_isEnabled = value;
					NotifyPropertyChanged ("IsEnabled");
				}
			}
		}

		private IRegionManager regionManager;
		public IRegionManager RegionManager
		{
			get
			{
				return regionManager;
			}
			private set
			{
				this.SetProperty<IRegionManager> (ref this.regionManager, value);
			}
		}

		private IEventAggregator eventAggregator;
		public IEventAggregator EventAggregator
		{
			get
			{
				return eventAggregator;
			}
			private set
			{
				this.SetProperty<IEventAggregator> (ref this.eventAggregator, value);
			}
		}

		private ISecurityService securityService;
		public ISecurityService SecurityService
		{
			get
			{
				return securityService;
			}

			private set
			{
				this.SetProperty<ISecurityService>(ref this.securityService, value);
			}
		}
		#endregion

		#region Flyout
		protected void ShowFlyout (string iFlyoutName)
		{
			var region = regionManager.Regions.ToList().Find(s => s.Name == "FlyoutControlRegion");

			if (region != null) {
				var flyout = region.Views.Where(s => s is Flyout && ((Flyout)s).Name == iFlyoutName).FirstOrDefault() as Flyout;

				if (flyout != null) {
					flyout.IsOpen = !flyout.IsOpen;
				}
			}
		}
		#endregion

		#region Constructor
		public ViewModelBase ()
		{
			this.RegionManager = ServiceLocator.Current.GetInstance<IRegionManager> ();
			this.EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator> ();
			this.SecurityService = ServiceLocator.Current.GetInstance<ISecurityService>();
		}
		#endregion

		#region Property Event
		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged (string iPropertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (iPropertyName));
			}
		}
		#endregion
	}
}
