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
	public class ProductEntityConfiguration: EntityTypeConfiguration<Product>
	{
		public ProductEntityConfiguration()
		{
			HasKey(p => p.Id);

			Property(p => p.BarCode).HasMaxLength(100).HasColumnAnnotation("Index",
					new IndexAnnotation(new[]
					{ new IndexAttribute("IDX_UK_PROD_BC")
					 { IsUnique = true }}));
			Property (p => p.Id).HasColumnOrder (1);
			Property (p => p.BarCode).HasColumnOrder (2);

			Property (p => p.BarCode).HasMaxLength (100);
			Property (p => p.Name).HasMaxLength (50);
		}
	}
}
