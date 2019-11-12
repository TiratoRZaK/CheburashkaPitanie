namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ResponsiblePerson = c.String(),
                        ConclusionDate = c.DateTime(nullable: false),
                        PeriodInMonths = c.Int(nullable: false),
                        FileName = c.String(),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.SellerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCompany = c.String(),
                        FullNameCompany = c.String(),
                        AddressCompany = c.String(),
                        INN = c.String(),
                        KPP = c.String(),
                        BIK = c.String(),
                        Bank = c.String(),
                        PersonalAccount = c.String(),
                        BankAccount = c.String(),
                        NameCustomer = c.String(),
                        NameCustomerSpec = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCompany = c.String(),
                        FullNameCompany = c.String(),
                        AddressCompany = c.String(),
                        Email = c.String(),
                        TypeSpec = c.String(),
                        PhoneNumber = c.String(),
                        INN = c.String(),
                        KPP = c.String(),
                        BIK = c.String(),
                        Bank = c.String(),
                        PersonalAccount = c.String(),
                        BankAccount = c.String(),
                        CorrespondentAccount = c.String(),
                        NameSeller = c.String(),
                        NameSellerSpec = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        FileName = c.String(),
                        GruzName = c.String(),
                        PriemName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ContractId = c.Int(nullable: false),
                        FileName = c.String(),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Norm = c.Single(nullable: false),
                        Vitamine_C = c.Int(),
                        Fat = c.Int(),
                        Protein = c.Int(),
                        Carbohydrate = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Kids = c.Int(nullable: false),
                        KidsB = c.Int(nullable: false),
                        FileName = c.String(),
                        Vrach = c.String(),
                        Povar = c.String(),
                        Klad = c.String(),
                        Rukowoditel = c.String(),
                        ProductBId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Norm = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PsevdoName = c.String(),
                        UnitId = c.Int(nullable: false),
                        Norm = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        Vitamine_C = c.Int(),
                        Protein = c.Int(),
                        Fat = c.Int(),
                        Carbohydrate = c.Int(),
                        Balance = c.Single(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDishes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Products", "TypeId", "dbo.Types");
            DropForeignKey("dbo.ProductDishes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DeliveryNotes", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Contracts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "TypeId" });
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropIndex("dbo.ProductDishes", new[] { "ProductId" });
            DropIndex("dbo.ProductDishes", new[] { "DishId" });
            DropIndex("dbo.Invoices", new[] { "ContractId" });
            DropIndex("dbo.DeliveryNotes", new[] { "InvoiceId" });
            DropIndex("dbo.Contracts", new[] { "CustomerId" });
            DropIndex("dbo.Contracts", new[] { "SellerId" });
            DropTable("dbo.Units");
            DropTable("dbo.Types");
            DropTable("dbo.Products");
            DropTable("dbo.ProductDishes");
            DropTable("dbo.Menus");
            DropTable("dbo.Dishes");
            DropTable("dbo.Invoices");
            DropTable("dbo.DeliveryNotes");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.Contracts");
        }
    }
}
