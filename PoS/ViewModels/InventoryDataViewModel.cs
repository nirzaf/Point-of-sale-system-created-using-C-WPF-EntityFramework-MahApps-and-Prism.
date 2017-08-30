using PoS.BL.Models;
using PoS.Dal.Mdl;
using Prism.Commands;
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

		public DelegateCommand AddCommand
		{
			get;
			private set;
		}

		public DelegateCommand EditCommand
		{
			get;
			private set;
		}

		public DelegateCommand DeleteCommand
		{
			get;
			private set;
		}

		public InventoryDataViewModel()
		{
			ProductList = new List<ProductModel>();

			StockTypeList = Enum.GetValues(typeof(EStockType)).Cast<EStockType>().ToList();
			SelectedStockType = EStockType.Qty;
			ProductList = InventoryService.GetAllProducts();
		}
	}
}
