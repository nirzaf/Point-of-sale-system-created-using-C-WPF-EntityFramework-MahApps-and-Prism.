using PoS.BL.Models;
using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.AutoMap
{
	public class UserMapper : BaseMapper<User, UserModel, UserModel>
	{
		public UserMapper()
			:base()
		{

		}
	}
}
