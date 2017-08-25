using System.Collections.Generic;

namespace PoS.Ctrls
{
	public class HamburgerMenu
	{
		public object Icon
		{
			get; set;
		}
		public string Label
		{
			get; set;
		}
		public object Tag
		{
			get; set;
		}

		public static IEnumerable<HamburgerMenu> GetMainItems (HamburgerMenu menu)
		{
			var items = new List<HamburgerMenu>();

			items.Add (new HamburgerMenu () {
				Icon = menu.Icon,
				Label = menu.Label,
				Tag = menu.Tag
			});

			return items;
		}
	}
}
