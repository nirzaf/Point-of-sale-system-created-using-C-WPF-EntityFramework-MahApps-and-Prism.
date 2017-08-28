using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.Models
{
	public class ProductModel
	{
		private Product _model;

		public string BarCode
		{
			get
			{
				return _model.BarCode;
			}
			set
			{
				_model.BarCode = value;
			}
		}

		public string Name
		{
			get
			{
				return _model.Name;
			}
			set
			{
				_model.Name = value;
			}
		}

		public double InStock
		{
			get
			{
				double qty = 0;

				switch (_model.StockType)
				{
					case EStockType.Length:
						qty = _model.StockLength;
						break;
					case EStockType.Qty:
						qty = _model.StockQty;
						break;
					case EStockType.Weight:
						qty = _model.StockWeight;
						break;
				}

				return qty;
			}
			set
			{
				switch (_model.StockType)
				{
					case EStockType.Qty:
						_model.StockQty = value;
						break;
					case EStockType.Weight:
						_model.StockWeight = value;
						break;
					case EStockType.Length:
					default:
						_model.StockLength = value;
						break;
				}
			}
		}

		public byte[] Image
		{
			get
			{
				return _model.Image;
			}
			set
			{
				_model.Image = value;
			}
		}

		public EStockType StockType
		{
			get
			{
				return _model.StockType;
			}
			set
			{
				_model.StockType = value;
			}
		}

		public double StockPrice
		{
			get
			{
				return _model.ProductCost;
			}
			set
			{
				_model.ProductCost = value;
			}
		}

		public double RetailPrice
		{
			get
			{
				return _model.RetailPrice;
			}
			set
			{
				_model.RetailPrice = value;
			}
		}

		public string Description
		{
			get
			{
				return _model.ProductDesc;
			}
			set
			{
				_model.ProductDesc = value;
			}
		}

		public int ProductId
		{
			get
			{
				return _model.Id;
			}
			set
			{
				_model.Id = value;
			}
		}

		public ProductModel()
		{
			_model = new Product();
		}

		public ProductModel(Product iModel)
		{
			_model = iModel;
		}
	}
}
