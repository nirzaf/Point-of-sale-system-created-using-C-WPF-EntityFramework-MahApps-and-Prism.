using PoS.Dal.Sql.Ctx.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public interface IPosUnitOfWork
	{
		IEmployeeRepository EmployeeRepo { get; }
		IUserRepository UserRepo { get; }
		IProductRepository ProductRepo { get; }
		IOrderRepository OrderRepo { get; }
		IOrderLineRepository OrderLineRepo { get; }

		int Commit();
	}
}
