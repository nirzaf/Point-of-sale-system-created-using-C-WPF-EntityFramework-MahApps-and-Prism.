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
		}

		public void Execute (string iViewName)
		{

		}

		public bool CanExecute (string iViewName)
		{
			bool		oRetStat		= false;

			if (ECommands.Inventory.ToString() == iViewName) {
				oRetStat = true;
			}

			return oRetStat;
		}
	}
}
