using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class OrderLineRepository : PoSBaseRepository<OrderLine>, IOrderLineRepository
	{
		public OrderLineRepository(IPoSContext context)
			: base(context)
		{
		}
	}
}
