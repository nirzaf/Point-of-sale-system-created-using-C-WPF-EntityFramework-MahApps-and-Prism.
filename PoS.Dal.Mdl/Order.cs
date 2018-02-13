using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Mdl
{
	public class Order: IModel
	{
		public string BarCode { get; set; }

		public int ProductId { get; set; }

		public double Qty { get; set; }

		public int OrderLineId { get; set; }

		public string OrderDescription { get; set; }

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
		public virtual OrderLine OrderLine { get; set; }
	}
}
