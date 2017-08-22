using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Configuration
{
	internal class EmployeeEntityConfiguration: EntityTypeConfiguration<Employee>
	{
		internal EmployeeEntityConfiguration ()
		{
			HasKey (e => new {
				e.Id,
				e.EmpCode
			});

			Property (e => e.FName).HasMaxLength (50);
			Property (e => e.LName).HasMaxLength (50);
			Property (e => e.MName).HasMaxLength (50);
		}
	}
}
