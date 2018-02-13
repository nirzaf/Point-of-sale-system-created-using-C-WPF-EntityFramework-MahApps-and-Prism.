using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Mdl
{
	/// <summary>
	/// Gender Enumeration
	/// </summary>
	public enum EGender
	{
		Male = 1,
		Female
	}

	/// <summary>
	/// Role Type Enumeration
	/// </summary>
	public enum ERoleType
	{
		Admin,
		PowerUser,
		User
	}

	/// <summary>
	/// Stock Type enumeration
	/// </summary>
	public enum EStockType
	{
		Qty,
		Weight,
		Length
	}
}
