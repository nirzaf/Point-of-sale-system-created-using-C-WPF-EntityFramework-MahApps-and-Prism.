using PoS.Dal.Mdl;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Events
{
	public class UserSecurityEvent : PubSubEvent<User>
	{
	}

	public class UserLogoutEvent : PubSubEvent
	{
	}
}
