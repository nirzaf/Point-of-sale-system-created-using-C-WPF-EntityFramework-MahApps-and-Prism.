using PoS.Dal.Mdl;
using PoS.Dal.Sql.Ctx;
using PoS.Dal.Sql.Ctx.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.Service.Base
{
	internal abstract class AbstractService
	{
		protected IPosUnitOfWork _uofw;
		public AbstractService (IPosUnitOfWork iUnitOfWork)
		{
			_uofw = iUnitOfWork;
		}
		public void Add<J> (J iEntity,
							PoSBaseRepository<J> iRepo) where J : class, IModel, new()
		{
			iRepo.Add (iEntity);
		}

		public void Delete<J> (J iEntity,
							PoSBaseRepository<J> iRepo) where J : class, IModel, new()
		{
			iRepo.Delete (iEntity);
		}

		public void Update<J> (J iEntity,
							PoSBaseRepository<J> iRepo) where J : class, IModel, new()
		{
			iRepo.Update (iEntity);
		}

		public int Commit ()
		{
			return _uofw.Commit ();
		}
	}
}
