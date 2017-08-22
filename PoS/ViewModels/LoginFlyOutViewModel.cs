using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class LoginFlyOutViewModel : ViewModelBase
	{
		private bool _isOpen;
		public bool IsOpenFlyout
		{
			get
			{
				return _isOpen;
			}
			set
			{
				if (_isOpen != value) {
					_isOpen = value;
					NotifyPropertyChanged ("IsOpenFlyout");
				}
			}
		}

		public DelegateCommand CancelCommand
		{
			get;
			private set;
		}

		public LoginFlyOutViewModel ()
		{
			CancelCommand = new DelegateCommand (CancelLogin);
		}

		private void CancelLogin ()
		{
			IsOpenFlyout = false;
		}
	}
}
