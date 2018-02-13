using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public interface IPosBaseRepository<J> where J : class, IModel, new()
	{
		void Delete(J entity);
		void Add(J entity);
		void Update(J entity);
		IEnumerable<J> GetAll();
		J GetById(int id);
	}
}
