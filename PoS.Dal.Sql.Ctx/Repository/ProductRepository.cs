using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public class ProductRepository : PoSBaseRepository<Product>, IProductRepository
	{
		public ProductRepository(IPoSContext context) 
			: base(context)
		{
		}

		public IEnumerable<Product> GetProductByStockType(EStockType iStockTye)
		{

			//_dbSet.ToList(); <--- Mabagal ya ini
			return _dbSet.Where(p => p.StockType == iStockTye); // <--- Ini 
		}

		public Product GetProductByCode(string barcode)
		{
			return _dbSet.Where(p => p.BarCode == barcode).FirstOrDefault();
		}
	}
}
