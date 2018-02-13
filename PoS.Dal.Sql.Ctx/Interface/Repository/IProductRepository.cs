using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public interface IProductRepository: IPosBaseRepository<Product>
	{
		IEnumerable<Product> GetProductByStockType(EStockType iStockTye);
		Product GetProductByCode(string barcode);
	}
}
