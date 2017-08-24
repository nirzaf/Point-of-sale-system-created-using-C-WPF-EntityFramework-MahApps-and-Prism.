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
	public class HomeTilesViewModel : ViewModelBase
	{
		public DelegateCommand<string> TileCommand
		{
			get;
			private set;
		}
		public HomeTilesViewModel ()
		{
			TileCommand = new DelegateCommand<string> (Execute, CanExecute).ObservesProperty (() => IsEnabled);
			EventAggregator.GetEvent<UserSecurityEvent> ().Subscribe (LoginCommand, true);
			EventAggregator.GetEvent<UserLogoutEvent> ().Subscribe (LogoutCommand, true);
		}

		public void Execute (string iViewName)
		{
			RegionManager.RequestNavigate ("MainRegion", iViewName);
		}

		public void LoginCommand (User usermodel)
		{
			Container.RegisterInstance (usermodel);
			TileCommand.RaiseCanExecuteChanged ();
		}

		public void LogoutCommand ()
		{
			User usermodel = new User();
			Container.RegisterInstance (usermodel);
			TileCommand.RaiseCanExecuteChanged ();
		}

		public bool CanExecute (string iViewName)
		{
			bool		oRetStat		= false;
			User		userModel		= new User();
			if (IsLogin(out userModel)) {
				oRetStat = true;
			}

			return oRetStat;
		}
	}
}
