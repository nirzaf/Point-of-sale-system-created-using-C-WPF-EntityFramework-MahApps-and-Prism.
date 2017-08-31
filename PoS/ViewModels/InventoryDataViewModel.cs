using PoS.BL;
using PoS.BL.Models;
using PoS.BL.Service;
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
		private bool _isAddEditMode;
		private IInventoryService _inventoryService;

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
					SelectedStockType = value.StockType;
				}
				_selectedProduct = value;
				NotifyPropertyChanged ("SelectedProduct");
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

		public bool IsAddEditMode
		{
			get
			{
				return _isAddEditMode;
			}

			private set
			{
				_isAddEditMode = value;
				NotifyPropertyChanged ("IsAddEditMode");
				NotifyPropertyChanged ("IsNormalMode");
			}
		}

		public bool IsNormalMode
		{
			get
			{
				return !_isAddEditMode;
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

		public DelegateCommand SaveCommand
		{
			get;
			private set;
		}

		public DelegateCommand CancelCommand
		{
			get;
			private set;
		}

		public DelegateCommand RefreshCommand
		{
			get;
			private set;
		}

		public InventoryDataViewModel()
		{
			User userModel = new User();
			ProductList = new List<ProductModel>();
			IsAddEditMode = false;
			StockTypeList = Enum.GetValues(typeof(EStockType)).Cast<EStockType>().ToList();
			SelectedStockType = EStockType.Qty;

			IsLogin (out userModel);

			_inventoryService = TServiceFactory.GetInventoryService (userModel.UserName);

			ProductList = _inventoryService.GetAllProducts();

			AddCommand = new DelegateCommand (Add);
			EditCommand = new DelegateCommand (Edit);
			DeleteCommand = new DelegateCommand (Delete);
			SaveCommand = new DelegateCommand (Save);
			CancelCommand = new DelegateCommand (Cancel);
			RefreshCommand = new DelegateCommand (Refresh);
		}

		#region View Events
		private void Add ()
		{
			IsAddEditMode = true;
			SelectedProduct = null;
			SelectedProduct = new ProductModel ();
		}

		private void Edit ()
		{
			if (SelectedProduct == null) {
				ShowMessage ("Please select a Product!");
				return;
			}
			IsAddEditMode = true;
		}

		private void Delete ()
		{

		}

		private void Save ()
		{
			// TODO: Checking and validations

			try {

				if (SelectedProduct.ProductId != 0) {
					_inventoryService.UpdateProduct (SelectedProduct);
				}
				else {
					_inventoryService.AddProduct (SelectedProduct);
				}
				ShowMessage ("Successfully Save Product!",
							 MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
				IsAddEditMode = false;
				Initialize ();
			}
			catch {
				ShowMessage ("Error in saving Product!");
			}
		}

		private void Cancel ()
		{
			IsAddEditMode = false;
			Initialize ();
		}

		private void Refresh ()
		{
			Initialize ();
		}
		#endregion

		#region Helper Methods
		private void Initialize ()
		{
			ProductList = new List<ProductModel> ();
			ProductList = _inventoryService.GetAllProducts ();
			SelectedProduct = null;
		}
		#endregion
	}
}
