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
		EmployeeRepository EmployeeRepo { get; }
		UserRepository UserRepo { get; }
		ProductRepository ProductRepo { get; }
		OrderRepository OrderRepo { get; }
		OrderLineRepository OrderLineRepo { get; }

		void Commit();
	}
}
