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
	public class EmployeeEntityConfiguration: EntityTypeConfiguration<Employee>
	{
		public EmployeeEntityConfiguration ()
		{
			HasKey (e => e.Id);

			Property(e => e.EmpCode).HasMaxLength(15)
				.HasColumnAnnotation("IDX_UQ_EMPCODE",
				new IndexAnnotation(new IndexAttribute("IDX_UQ_EMPCODE")
				{ IsUnique = true }));
			Property (e => e.FName).HasMaxLength (50);
			Property (e => e.LName).HasMaxLength (50);
			Property (e => e.MName).HasMaxLength (50);
		}
	}
}
