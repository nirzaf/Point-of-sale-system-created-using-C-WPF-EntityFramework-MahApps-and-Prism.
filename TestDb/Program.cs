using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoS.Dal.Mdl;
using PoS.Dal.Sql.Ctx;
using PoS.Dal.Sql.Ctx.Repository;

namespace TestDb
{
	class Program
	{
		static void Main (string[] args)
		{
			PoSDbTransact dbTransact = new PoSDbTransact("PosDbConn");

			var users = dbTransact.UnitOfWork.UserRepo.GetAll ().ToList ();
		}
	}
}
