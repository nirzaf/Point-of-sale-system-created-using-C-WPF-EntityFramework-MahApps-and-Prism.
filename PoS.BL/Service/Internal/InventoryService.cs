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
		private readonly IProductRepository _productRepo;
		public InventoryService(IPosUnitOfWork iUnitOfWork,
								IProductRepository iProductRepo)
			:base (iUnitOfWork)
		{
			_productRepo = iProductRepo;
		}
		public void AddProduct(ProductModel iModel)
		{
			Product product = iModel.GetProduct();

			product.CreatedDate = DateTime.Now;
			product.ModifiedDate = DateTime.Now;

			_productRepo.Add(product);
			_uofw.Commit();
		}

		public void UpdateProduct (ProductModel iModel)
		{
			Product product = iModel.GetProduct();

			product.ModifiedDate = DateTime.Now;
			_productRepo.Update (product);
			_uofw.Commit ();
		}

		public void DeleteProduct(ProductModel iModel)
		{
			_productRepo.Delete(iModel.GetProduct());
			_uofw.Commit ();
		}

		public List<ProductModel> GetAllProducts()
		{
			return _productRepo.GetAll().Select(p => new ProductModel(p)).ToList();
		}

		public ProductModel GetProductByBarCode(string iCode)
		{
			Product product = new Product();
			ProductModel oModel = null;

			product = _productRepo.GetProductByCode(iCode);

			if (product != null)
			{
				oModel = new ProductModel(product);
			}

			return oModel;
		}
	}
}
