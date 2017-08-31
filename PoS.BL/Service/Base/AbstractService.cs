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
		internal AbstractService (IPosUnitOfWork iUnitOfWork)
		{
			_uofw = iUnitOfWork;
		}
		internal void Add<J> (J iEntity,
							PoSBaseRepository<J> iRepo) where J : class, IModel, new()
		{
			iRepo.Add (iEntity);
		}

		internal void Delete<J> (J iEntity,
							PoSBaseRepository<J> iRepo) where J : class, IModel, new()
		{
			iRepo.Delete (iEntity);
		}

		internal void Update<J> (J iEntity,
							PoSBaseRepository<J> iRepo) where J : class, IModel, new()
		{
			iRepo.Update (iEntity);
		}

		internal int Commit ()
		{
			return _uofw.Commit ();
		}
	}
}
