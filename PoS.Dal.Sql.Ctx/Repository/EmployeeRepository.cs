using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class EmployeeRepository : PoSBaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository (IPoSContext context) 
			: base (context)
		{

		}

		public Employee GetEmployeeByEmpCode (string code)
		{
			return _dbSet.FirstOrDefault(e => e.EmpCode == code);
		}
	}
}
