using PoS.Dal.Mdl;
using PoS.Dal.Sql.Ctx.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public interface IPoSContext: IDataContextBase, IDisposable
	{
		DbSet<User> Users { get; set; }

		DbSet<Employee> Employees { get; set; }

		DbSet<Order> Orders { get; set; }

		DbSet<OrderLine> OrderLines { get; set; }

		DbSet<Product> Products { get; set; }

		int CommitChanges();
	}
}
