using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Configuration
{
	internal class ProductEntityConfiguration: EntityTypeConfiguration<Product>
	{
		internal ProductEntityConfiguration ()
		{
			HasKey (p => new {
				p.Id,
				p.BarCode
			});

			Property (p => p.BarCode).HasMaxLength (100);
			Property (p => p.Name).HasMaxLength (50);
		}
	}
}
