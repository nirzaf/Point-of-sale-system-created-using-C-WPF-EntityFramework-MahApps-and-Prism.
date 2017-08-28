using PoS.BL.Models;
using PoS.Dal.Mdl;
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
		private ProductModel _selectedProduct;
		private List<EStockType> _stockTypeList;
		private EStockType _selectedStockType;

		public ProductModel SelectedProduct
		{
			get
			{
				return _selectedProduct;
			}
			set
			{
				if (value != null)
				{
					_selectedProduct = value;
					SelectedStockType = _selectedProduct.StockType;
				}
				NotifyPropertyChanged("SelectedProduct");
			}
		}

		public EStockType SelectedStockType
		{
			get
			{
				return _selectedStockType;
			}
			set
			{
				if (_selectedStockType != value)
				{
					_selectedStockType = value;
					NotifyPropertyChanged("SelectedStockType");
				}
			}
		}

		public List<EStockType> StockTypeList
		{
			get
			{
				return _stockTypeList;
			}
			set
			{
				_stockTypeList = value;
				NotifyPropertyChanged("StockTypeList");
			}
		}

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
				prod.StockPrice = Math.Round(price, 2);
				prod.RetailPrice = Math.Round(price * 1.05, 2);
				prod.StockType = Dal.Mdl.EStockType.Qty;
				prod.InStock = Math.Round(qty);

				tmpProduct.Add(prod);
			}

			StockTypeList = Enum.GetValues(typeof(EStockType)).Cast<EStockType>().ToList();
			SelectedStockType = EStockType.Qty;

			ProductList = tmpProduct;
		}
	}
}
