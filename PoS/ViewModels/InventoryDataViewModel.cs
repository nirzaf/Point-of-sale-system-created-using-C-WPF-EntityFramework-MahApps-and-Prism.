using PoS.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.ViewModels
{
	public class InventoryDataViewModel : ViewModelBase
	{
		private List<ProductModel> _productList;

		public List<ProductModel> ProductList
		{
			get
			{
				return _productList;
			}
			set
			{
				_productList = value;
				NotifyPropertyChanged("ProductList");
			}
		}
		public InventoryDataViewModel()
		{
			ProductList = new List<ProductModel>();
			List<ProductModel> tmpProduct = new List<ProductModel>();
			Random rand = new Random(2500);
			for(int idx = 0; idx < 100; idx++)
			{
				ProductModel prod = new ProductModel();
				double price = rand.NextDouble() * 1000;
				double qty = rand.NextDouble() * 500;

				prod.BarCode = (idx + 1).ToString("00000000000");
				prod.Name = "Product No. " + (idx + 1).ToString();
				prod.StockPrice = price;
				prod.RetailPrice = price * 1.05;
				prod.StockType = Dal.Mdl.EStockType.Qty;
				prod.InStock = Math.Round(qty);

				tmpProduct.Add(prod);
			}

			ProductList = tmpProduct;
		}
	}
}
