using Microsoft.Practices.Unity;
using PoS.BL.Service;
using PoS.BL.Service.Internal;
using PoS.Dal.Sql.Ctx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL
{
	public class UnitRegistrationBL
	{
		public static void Setup(IUnityContainer container)
		{
			UnityRegistrationDbCtx.Setup(container);
			container.RegisterType<ISecurityService, SecurityService>();
			container.RegisterType<IInventoryService, InventoryService>();
		}
	}
}
