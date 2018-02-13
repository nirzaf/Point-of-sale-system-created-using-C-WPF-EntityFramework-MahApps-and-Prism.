using Microsoft.Practices.Unity;
using PoS.Dal.Sql.Ctx.Context;
using PoS.Dal.Sql.Ctx.Repository;
using PoS.Dal.Sql.Ctx.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx
{
	public class UnityRegistrationDbCtx
	{
		public static void Setup(IUnityContainer container)
		{
			container.RegisterType<IPoSContext, PoSContext>();
			container.RegisterType<IPosUnitOfWork, PoSUnitOfWork>();
			container.RegisterType<IUserRepository, UserRepository>();
			container.RegisterType<IProductRepository, ProductRepository>();
		}
	}
}
