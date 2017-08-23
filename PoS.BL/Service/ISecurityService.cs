using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.Service
{
	public interface ISecurityService
	{
		List<User> GetAllUsers();
		User Login(string username, string password);
	}
}
