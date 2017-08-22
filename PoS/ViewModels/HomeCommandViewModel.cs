using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class HomeCommandViewModel : ViewModelBase
	{
		IRegionNavigationJournal _journal;

		public DelegateCommand HomeCommand
		{
			get;
			set;
		}

		#region Constructor
		public HomeCommandViewModel ()
		{
			HomeCommand = new DelegateCommand (GoBack, CanGoHome).ObservesProperty (() => IsEnabled);
		}
		#endregion

		#region Commands
		private void GoBack ()
		{
			if (_journal != null) {
				_journal.GoBack ();
			}
		}

		private bool CanGoHome ()
		{
			return IsEnabled;
		}
		#endregion
	}
}
