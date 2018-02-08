namespace PoS.Dal.Sql.Ctx.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpCode = c.String(maxLength: 15,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IDX_UQ_EMPCODE",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IDX_UQ_EMPCODE, IsUnique: True }")
                                },
                            }),
                        FName = c.String(maxLength: 50),
                        LName = c.String(maxLength: 50),
                        MName = c.String(maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        ExitDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Position = c.String(),
                        Image = c.Binary(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Points = c.Double(nullable: false),
                        Remarks = c.String(),
                        ItemCount = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.String(maxLength: 100),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        OrderLineId = c.Int(nullable: false),
                        OrderDescription = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BarCode, unique: true, name: "IDX_UQ_ORDBC");
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 50),
                        ProductDesc = c.String(),
                        StockQty = c.Double(nullable: false),
                        StockWeight = c.Double(nullable: false),
                        StockLength = c.Double(nullable: false),
                        StockType = c.Int(nullable: false),
                        RetailPrice = c.Double(nullable: false),
                        ProductCost = c.Double(nullable: false),
                        CriticalLimit = c.Double(nullable: false),
                        Image = c.Binary(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.BarCode, unique: true, name: "IDX_UK_PROD_BC");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 15),
                        Password = c.String(maxLength: 15),
                        FName = c.String(),
                        LName = c.String(maxLength: 30),
                        MName = c.String(maxLength: 30),
                        IsActive = c.Boolean(nullable: false),
                        RoleType = c.Int(nullable: false),
                        Image = c.Binary(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "IDX_UQ_USERNAME");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "IDX_UQ_USERNAME");
            DropIndex("dbo.Products", "IDX_UK_PROD_BC");
            DropIndex("dbo.Orders", "IDX_UQ_ORDBC");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Employees",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "EmpCode",
                        new Dictionary<string, object>
                        {
                            { "IDX_UQ_EMPCODE", "IndexAnnotation: { Name: IDX_UQ_EMPCODE, IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
