using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class UserRepository : PoSBaseRepository<User>, IUserRepository
	{
		public UserRepository (IPoSContext iContext)
			: base (iContext)
		{

		}

		public bool LogIn (string iUsername, string iPass)
		{
			// TODO: Add Encryption and Decrypt
			return _dbSet.Any(u => u.UserName == iUsername &&
							 u.Password == iPass);
		}

		public User GetUserByUserName (string iUserName)
		{
			return _dbSet.FirstOrDefault(u => u.UserName == iUserName);
		}
	}
}
