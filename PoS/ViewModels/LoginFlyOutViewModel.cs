using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
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
	public class LoginFlyOutViewModel : ViewModelBase
	{
		private bool _isOpen;
		private string _username;
		private string _password;

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

		public string UserName
		{
			get
			{
				return _username;
			}

			set
			{
				if (_username != value) {
					_username = value;
					NotifyPropertyChanged ("UserName");
				}
			}
		}

		public string Password
		{
			get
			{
				return _password;
			}

			set
			{
				if (_password != value) {
					_password = value;
					NotifyPropertyChanged ("Password");
				}
			}
		}

		public DelegateCommand CancelCommand
		{
			get;
			private set;
		}

		public DelegateCommand LoginCommand
		{
			get;
			private set;
		}

		public LoginFlyOutViewModel ()
		{
			CancelCommand = new DelegateCommand (CancelLogin);
			LoginCommand = new DelegateCommand (Login);
		}

		private void Login ()
		{
			User user = new User();
			user = SecurityService.Login (_username, _password);

			if (user == null) {
				ShowMessage ("Incorrect Username / password");
			}
			else {
				EventAggregator.GetEvent<UserSecurityEvent> ().Publish (user);
				IsOpenFlyout = false;
				UserName = string.Empty;
				Password = string.Empty;
			}
		}

		private void CancelLogin ()
		{
			IsOpenFlyout = false;
		}
	}
}
