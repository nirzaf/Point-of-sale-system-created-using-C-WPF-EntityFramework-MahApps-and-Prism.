using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.BL.Models;
using PoS.Dal.Sql.Ctx;
using PoS.Dal.Mdl;
using PoS.BL.Service.Base;

namespace PoS.BL.Service.Internal
{
	internal class InventoryService : AbstractService, IInventoryService
	{
		public InventoryService(IPosUnitOfWork iUnitOfWork)
			:base (iUnitOfWork)
		{
		}
		public void AddProduct(string iUser, ProductModel iModel)
		{
			Product product = iModel.GetProduct();

			product.CreatedBy = iUser;
			product.CreatedDate = DateTime.Now;
			product.ModifiedBy = iUser;
			product.ModifiedDate = DateTime.Now;

			_uofw.ProductRepo.Add(product);
			_uofw.Commit();
		}

		public void UpdateProduct (string iUser, ProductModel iModel)
		{
			Product product = iModel.GetProduct();

			product.ModifiedBy = iUser;
			product.ModifiedDate = DateTime.Now;

			_uofw.ProductRepo.Update (product);
			_uofw.Commit ();
		}

		public void DeleteProduct(ProductModel iModel)
		{
			_uofw.ProductRepo.Delete(iModel.GetProduct());
		}

		public List<ProductModel> GetAllProducts()
		{
			return _uofw.ProductRepo.GetAll().Select(p => new ProductModel(p)).ToList();
		}

		public ProductModel GetProductByBarCode(string iCode)
		{
			Product product = new Product();
			ProductModel oModel = null;

			product = _uofw.ProductRepo.GetProductByCode(iCode);

			if (product != null)
			{
				oModel = new ProductModel(product);
			}

			return oModel;
		}
	}
}
