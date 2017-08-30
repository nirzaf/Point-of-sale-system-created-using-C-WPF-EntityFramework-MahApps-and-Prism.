using PoS.Dal.Mdl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoS.Dal.Sql.Ctx.Context
{
	internal class PoSCreateNotExist: CreateDatabaseIfNotExists<PoSContext>
	{
		protected override void Seed(PoSContext context)
		{

			User user = new User();

			user.Id = 1;
			user.IsActive = true;
			user.LName = "Admin";
			user.MName = "Admin";
			user.FName = "Admin";
			user.CreatedBy = "admin";
			user.ModifiedBy = "admin";
			user.CreatedDate = DateTime.Now;
			user.ModifiedDate = DateTime.Now;
			user.UserName = "admin";
			user.Password = "@dm1n";
			user.RoleType = ERoleType.Admin;

			context.Users.Add (user);

			List<Product> tmpProduct = new List<Product>();
			Random rand = new Random(2500);
			for (int idx = 0; idx < 100; idx++) {
				Product prod = new Product();
				double price = rand.NextDouble() * 1000;
				double qty = rand.NextDouble() * 500;

				prod.BarCode = (idx + 1).ToString("00000000000");
				prod.Name = "Product No. " + (idx + 1).ToString();
				prod.ProductCost = Math.Round(price, 2);
				prod.RetailPrice = Math.Round(price * 1.05, 2);
				prod.StockType = Dal.Mdl.EStockType.Qty;
				prod.StockQty = Math.Round(qty);
				prod.CreatedBy = "admin";
				prod.ModifiedBy = "admin";
				prod.CreatedDate = DateTime.Now;
				prod.ModifiedDate = DateTime.Now;
				tmpProduct.Add(prod);
			}

			context.Products.AddRange(tmpProduct);

			base.Seed (context);
		}
	}
}
