using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Interface
{
	public interface IDataContextBase
	{
		IDbSet<T> Set<T>() where T: class;
		DbEntityEntry<T> Entry<T>(T entry) where T : class;
	}
}
