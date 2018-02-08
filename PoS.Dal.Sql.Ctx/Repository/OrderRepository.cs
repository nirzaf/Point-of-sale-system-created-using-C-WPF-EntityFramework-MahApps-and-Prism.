using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class OrderRepository : PoSBaseRepository<Order>
	{
		public OrderRepository(IPoSContext context) 
			: base(context)
		{

		}

		public IEnumerable<Order> GetOrdersByOrderLineId(int orderLineId)
		{
			return _dbSet.Where(o => o.OrderLineId == orderLineId);
		}
	}
}
