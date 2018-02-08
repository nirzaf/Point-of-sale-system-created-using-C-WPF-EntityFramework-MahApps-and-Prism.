using PoS.Dal.Sql.Ctx.Context;
using PoS.Dal.Sql.Ctx.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public class PoSDbTransact
	{
		private PoSContext _context;
		private PoSUnitOfWork _unitofwork;

		public IPoSContext DbContext
		{
			get
			{
				return _context;
			}
		}

		public IPosUnitOfWork UnitOfWork
		{
			get
			{
				return _unitofwork;
			}
		}

		public PoSDbTransact(string connstring)
		{
			_context = new PoSContext();
			_unitofwork = new PoSUnitOfWork(_context);
		}
	}
}
