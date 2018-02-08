using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Repository
{
	public abstract class PoSBaseRepository<J> where J : class, IModel, new ()
	{
		protected IPoSContext _context;
		protected IDbSet<J> _dbSet;

		public PoSBaseRepository (IPoSContext context)
		{
			if (context == null) {
				throw new ArgumentNullException ("context", message: "context must not be null!");
			}

			_context = context;
			_dbSet = context.Set<J> ();
		}

		public virtual void Add (J entity)
		{
			if (entity == null)
				throw new ArgumentNullException ("entity", message: "entity must not be null!");

			_dbSet.Add (entity);
			EntityState state = _context.Entry(entity).State;
		}

		public virtual void Delete (J entity)
		{
			if (entity == null)
				throw new ArgumentNullException ("entity", message: "entity must not be null!");

			_dbSet.Remove (entity);
		}

		public virtual void Update (J entity)
		{
			if (entity == null)
				throw new ArgumentNullException ("entity", message: "entity must not be null!");

			_dbSet.Attach (entity);
			_context.Entry (entity).State = EntityState.Modified;
		}

		public virtual IEnumerable<J> GetAll ()
		{
			return _dbSet.AsEnumerable ();
		}

		public virtual J GetById(int id)
		{
			return _dbSet.Where(s => s.Id == id).FirstOrDefault();
		}
	}
}
