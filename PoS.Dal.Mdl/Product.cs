using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Mdl
{
	public class Product: IModel
	{
		public string BarCode { get; set; }

		public string Name { get; set; }

		public string ProductDesc { get; set; }

		public double StockQty { get; set; }

		public double StockWeight { get; set; }

		public double StockLength { get; set; }

		public EStockType StockType { get; set; }

		public double RetailPrice { get; set; }

		public double ProductCost { get; set; }

		public double CriticalLimit { get; set; }

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

		public Product()
		{
			CriticalLimit = 5;
		}
	}
}
