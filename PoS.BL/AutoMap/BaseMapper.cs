using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.BL.AutoMap
{
	public abstract class BaseMapper<TDbItem, TBLModel, TCreateModel>
	{
		protected MapperConfiguration mapConfig;

		public BaseMapper()
		{
			mapConfig = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<TDbItem, TBLModel>();
				cfg.CreateMap<TBLModel, TDbItem>();
				cfg.CreateMap<TCreateModel, TDbItem>();
			});
		}
	}
}
