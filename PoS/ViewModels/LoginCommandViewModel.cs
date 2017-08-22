using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class LoginCommandViewModel : ViewModelBase
	{
		private string _loginText;
		public string LoginText
		{
			get
			{
				return _loginText;
			}
			set
			{
				if (_loginText != value) {
					_loginText = value;
					NotifyPropertyChanged ("LoginText");
				}
			}
		}

		public DelegateCommand LoginCommand
		{
			get;
			private set;
		}

		public LoginCommandViewModel ()
		{
			LoginCommand = new DelegateCommand (ShowLoginFlyout);
		}

		private void ShowLoginFlyout ()
		{
			ShowFlyout ("FlyoutLogin");
		}
	}
}
