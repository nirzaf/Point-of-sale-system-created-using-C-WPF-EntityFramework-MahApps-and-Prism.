using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class UserRepository : PoSBaseRepository<User>
	{
		public UserRepository (IPoSContext iContext)
			: base (iContext)
		{

		}

		public bool LogIn (string iUsername, string iPass)
		{
			int userCnt = 
				_dbSet.Where (u => u.UserName == iUsername &&
							  u.Password == iPass).Count ();

			return userCnt != 0;
		}

		public User GetUserByUserName (string iUserName)
		{
			User    oMdl = new User();

			oMdl = _dbSet.Where (u => u.UserName == iUserName).FirstOrDefault ();

			return oMdl;
		}
	}
}
