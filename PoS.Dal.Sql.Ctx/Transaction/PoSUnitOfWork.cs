using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoS.Dal.Sql.Ctx.Repository;
using PoS.Dal.Sql.Ctx.Context;

namespace PoS.Dal.Sql.Ctx.Transaction
{
	internal class PoSUnitOfWork : IPosUnitOfWork, IDisposable
	{
		private bool _isDispose;
		private EmployeeRepository _empRepo;
		private UserRepository _userRepo;
		private ProductRepository _productRepo;
		private OrderRepository _orderRepo;
		private OrderLineRepository _orderLineRepo;

		private IPoSContext _context;

		public IEmployeeRepository EmployeeRepo
		{
			get
			{
				return _empRepo;
			}
		}

		public IUserRepository UserRepo
		{
			get
			{
				return _userRepo;
			}
		}

		public IProductRepository ProductRepo
		{
			get
			{
				return _productRepo;
			}
		}

		public IOrderRepository OrderRepo
		{
			get
			{
				return _orderRepo;
			}
		}

		public IOrderLineRepository OrderLineRepo
		{
			get
			{
				return _orderLineRepo;
			}
		}

		public PoSUnitOfWork(IPoSContext context)
		{
			_context = context;
			_empRepo = new EmployeeRepository(_context);
			_userRepo = new UserRepository(_context);
			_productRepo = new ProductRepository(_context);
			_orderRepo = new OrderRepository(_context);
			_orderLineRepo = new OrderLineRepository(_context);
		}

		public int Commit()
		{
			int			oRetStat = 0;
			_context.CommitChanges();

			return oRetStat;
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		~PoSUnitOfWork ()
		{
			Dispose (false);
		}

		private void Dispose (bool disposing)
		{
			if (_isDispose) return;

			if (disposing) _context.Dispose ();

			_isDispose = true;
		}
	}
}
