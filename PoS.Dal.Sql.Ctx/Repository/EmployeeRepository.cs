using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class EmployeeRepository : PoSBaseRepository<Employee>
	{
		public EmployeeRepository (IPoSContext context) 
			: base (context)
		{

		}

		public Employee GetEmployeeByEmpCode (string code)
		{
			Employee oMdl = new Employee();

			oMdl = _dbSet.Where (e => e.EmpCode == code).FirstOrDefault ();

			return oMdl;
		}
	}
}
