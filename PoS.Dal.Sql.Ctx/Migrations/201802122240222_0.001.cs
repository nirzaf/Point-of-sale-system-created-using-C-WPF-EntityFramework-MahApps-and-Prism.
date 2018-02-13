namespace PoS.Dal.Sql.Ctx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0001 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "OrderLineId");
            AddForeignKey("dbo.Orders", "OrderLineId", "dbo.OrderLines", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderLineId", "dbo.OrderLines");
            DropIndex("dbo.Orders", new[] { "OrderLineId" });
        }
    }
}
