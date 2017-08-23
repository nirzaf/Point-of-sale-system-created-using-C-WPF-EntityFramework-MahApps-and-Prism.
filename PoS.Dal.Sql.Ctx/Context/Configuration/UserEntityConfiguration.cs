using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Configuration
{
	public class UserEntityConfiguration: EntityTypeConfiguration<User>
	{
		public UserEntityConfiguration ()
		{
			HasKey (u => new {
				u.Id,
				u.UserName
			});

			Property (p => p.UserName).HasMaxLength (30);
			Property (p => p.LName).HasMaxLength (30);
			Property (p => p.MName).HasMaxLength (30);
			Property (p => p.Password).HasMaxLength (15);
		}
	}
}
