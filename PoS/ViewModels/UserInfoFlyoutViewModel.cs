using PoS.Dal.Mdl;
using PoS.Events;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class UserInfoFlyoutViewModel : ViewModelBase
	{
		private User _userModel;
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

		private string _fullName;
		public string FullName
		{
			get
			{
				return _fullName;
			}
			set
			{
				if (_fullName != value) {
					_fullName = value;
					NotifyPropertyChanged ("FullName");
				}
			}
		}

		public DelegateCommand LogoutCommand
		{
			get;
			private set;
		}

		public UserInfoFlyoutViewModel ()
		{
			EventAggregator.GetEvent<UserSecurityEvent> ().Subscribe (LoginUser);
			LogoutCommand = new DelegateCommand (Logout);
		}

		private void Logout ()
		{
			IsOpenFlyout = false;
			EventAggregator.GetEvent<UserLogoutEvent> ().Publish ();
		}

		private void LoginUser (User iUser)
		{
			_userModel = iUser;
			FullName = string.Format ("{0}, {1}", iUser.LName, iUser.FName);
		}
	}
}
