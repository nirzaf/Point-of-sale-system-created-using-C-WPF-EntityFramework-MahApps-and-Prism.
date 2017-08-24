using MySql.Data.Entity;
using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Context
{
	[DbConfigurationType (typeof (MySqlEFConfiguration))]
	internal class PoSContext : DbContext, IPoSContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderLine> OrderLines { get; set; }

		public DbSet<Product> Products { get; set; }

		internal PoSContext(string connstring)
			: base (connstring)
		{
			Database.SetInitializer(new PoSCreateNotExist ());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			_RegisterConfig(modelBuilder, _GetAllConfig());
			base.OnModelCreating(modelBuilder);
		}

		/// <summary>
		/// Register Configurations
		/// </summary>
		/// <param name="modelBuilder">[in] Model Builder</param>
		/// <param name="configList">[in] Configuration List</param>
		private void _RegisterConfig(DbModelBuilder modelBuilder,
									  IEnumerable<Type> configList)
		{
			foreach (var type in configList)
			{
				dynamic config = Activator.CreateInstance(type);
				if (config != null)
				{
					modelBuilder.Configurations.Add(config);
				}
			}
		}

		/// <summary>
		/// Get All Configuration
		/// </summary>
		/// <returns>
		/// Configuration List
		/// </returns>
		private IEnumerable<Type> _GetAllConfig()
		{
			var types = Assembly.GetExecutingAssembly().GetTypes();
			var entityConfig = Assembly.GetExecutingAssembly().GetTypes()
				.Where(type => !string.IsNullOrEmpty(type.Namespace))
				.Where(type => type.BaseType != null &&
							   type.BaseType.IsGenericType &&
							   type.BaseType.GetGenericTypeDefinition() ==
							   typeof(EntityTypeConfiguration<>));

			return entityConfig;
		}
	}
}
