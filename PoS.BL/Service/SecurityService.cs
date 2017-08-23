using PoS.Dal.Mdl;
using PoS.Dal.Sql.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.Service
{
	internal class SecurityService: ISecurityService
	{
		private IPosUnitOfWork _uofw;
		internal SecurityService(IPosUnitOfWork unitofwork)
		{
			_uofw = unitofwork;
		}

		public List<User> GetAllUsers()
		{
			return _uofw.UserRepo.GetAll().ToList();
		}

		public User Login(string username, string password)
		{
			return _uofw.UserRepo.GetAll().Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
		}
	}
}
