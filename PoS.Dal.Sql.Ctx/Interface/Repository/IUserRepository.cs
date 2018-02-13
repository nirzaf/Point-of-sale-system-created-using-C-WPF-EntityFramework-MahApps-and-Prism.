using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public interface IUserRepository: IPosBaseRepository<User>
	{
		User GetUserByUserName(string iUserName);
		bool LogIn(string iUsername, string iPass);
	}
}
