using PoS.Dal.Mdl;
using PoS.Events;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class HomeCommandViewModel : ViewModelBase, INavigationAware
	{
		IRegionNavigationJournal _journal;
		IRegion _region;

		public DelegateCommand HomeCommand
		{
			get;
			set;
		}

		private bool _isEnable;
		public bool IsEnable
		{
			get
			{
				return _isEnable;
			}
			set
			{
				_isEnable = value;
				NotifyPropertyChanged ("IsEnable");
			}
		}

		#region Constructor
		public HomeCommandViewModel ()
		{
			_region = RegionManager.Regions["MainRegion"];
			HomeCommand = new DelegateCommand (GoBack, CanGoHome).ObservesProperty (() => IsEnable);
			EventAggregator.GetEvent<UserSecurityEvent> ().Subscribe (OnLoginCommand, true);
			EventAggregator.GetEvent<UserLogoutEvent> ().Subscribe (OnLogoutCommand, true);
		}
		#endregion

		#region Commands

		private void OnLogoutCommand ()
		{
			_journal.Clear ();
			IsEnable = false;
		}

		private void OnLoginCommand (User iUser)
		{
			_journal = _region.NavigationService.Journal;
			IsEnable = true;
		}
		private void GoBack ()
		{
			if (_journal.CanGoBack == false) {
				RegionManager.RequestNavigate ("MainRegion", "HomeTilesView");
			}
			else {
				_journal.GoBack ();
			}
		}

		private bool CanGoHome ()
		{
			return IsEnable;
		}

		public void OnNavigatedTo (NavigationContext navigationContext)
		{
			_journal = navigationContext.NavigationService.Journal;
			HomeCommand.RaiseCanExecuteChanged ();
		}

		public bool IsNavigationTarget (NavigationContext navigationContext)
		{
			return _journal.CanGoBack;
		}

		public void OnNavigatedFrom (NavigationContext navigationContext)
		{
		}
		#endregion
	}
}
