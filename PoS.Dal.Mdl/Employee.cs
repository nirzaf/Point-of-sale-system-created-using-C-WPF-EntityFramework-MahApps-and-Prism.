using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Mdl
{
	public class Employee: IModel
	{
		public string EmpCode { get; set; }

		public string FName { get; set; }

		public string LName { get; set; }

		public string MName { get; set; }

		public DateTime BirthDate { get; set; }

		public DateTime EntryDate { get; set; }

		public DateTime ExitDate { get; set; }

		public bool IsActive { get; set; }

		public string Position { get; set; }

		public byte[] Image
		{
			get; set;
		}

		public int Id
		{
			get; set;
		}
		public string CreatedBy
		{
			get; set;
		}
		public DateTime CreatedDate
		{
			get; set;
		}
		public string ModifiedBy
		{
			get; set;
		}
		public DateTime ModifiedDate
		{
			get; set;
		}
	}
}
