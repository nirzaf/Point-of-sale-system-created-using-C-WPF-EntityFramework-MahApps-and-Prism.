using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Context
{
	internal class PoSCreateNotExist: CreateDatabaseIfNotExists<PoSContext>
	{
		protected override void Seed(PoSContext context)
		{

			User user = new User();

			user.Id = 1;
			user.IsActive = true;
			user.LName = "Admin";
			user.MName = "Admin";
			user.FName = "Admin";
			user.CreatedBy = "admin";
			user.ModifiedBy = "admin";
			user.CreatedDate = DateTime.Now;
			user.ModifiedDate = DateTime.Now;
			user.UserName = "admin";
			user.Password = "@dm1n";
			user.RoleType = ERoleType.Admin;

			context.Users.Add (user);
			base.Seed (context);
		}
	}
}
