using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.Models
{
	public class UserModel: IModel
	{
		public string UserName
		{
			get; set;
		}

		public string Password
		{
			get; set;
		}

		public string FName
		{
			get; set;
		}

		public string LName
		{
			get; set;
		}

		public string MName
		{
			get; set;
		}

		public bool IsActive
		{
			get; set;
		}

		public ERoleType RoleType
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
