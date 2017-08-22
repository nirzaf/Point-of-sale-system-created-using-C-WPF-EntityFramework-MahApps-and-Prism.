using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Configuration
{
	internal class OrderLineEntityConfiguration: EntityTypeConfiguration<OrderLine>
	{
		internal OrderLineEntityConfiguration ()
		{
			HasKey (ol => ol.Id);
		}
	}
}
