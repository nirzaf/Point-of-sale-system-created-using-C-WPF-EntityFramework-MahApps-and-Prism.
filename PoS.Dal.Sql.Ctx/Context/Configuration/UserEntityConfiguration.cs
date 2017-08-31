using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
			HasKey (u => u.Id);

			Property(p => p.UserName).HasMaxLength(15).HasColumnAnnotation("Index",
							new IndexAnnotation
							(new IndexAttribute("IDX_UQ_USERNAME")
							{ IsUnique = true }));
			Property (p => p.LName).HasMaxLength (30);
			Property (p => p.MName).HasMaxLength (30);
			Property (p => p.Password).HasMaxLength (15);
		}
	}
}
