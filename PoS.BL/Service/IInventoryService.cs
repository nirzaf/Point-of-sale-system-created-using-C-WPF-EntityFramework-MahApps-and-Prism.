using PoS.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.Service
{
	public interface IInventoryService
	{
		List<ProductModel> GetAllProducts();
		ProductModel GetProductByBarCode(string iCode);
	}
}
