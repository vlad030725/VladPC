namespace VladPC.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Company",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Product",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Int(),
                        Count = c.Int(),
                        IdCompany = c.Int(),
                        IdTypeProduct = c.Int(),
                        CountCores = c.Int(),
                        CountStreams = c.Int(),
                        Frequency = c.Int(),
                        IdSocket = c.Int(),
                        CountMemory = c.Int(),
                        IdTypeMemory = c.Int(),
                        IdFormFactor = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.FormFactor", t => t.IdFormFactor)
                .ForeignKey("public.Socket", t => t.IdSocket)
                .ForeignKey("public.TypeMemory", t => t.IdTypeMemory)
                .ForeignKey("public.TypeProduct", t => t.IdTypeProduct)
                .ForeignKey("public.Company", t => t.IdCompany)
                .Index(t => t.IdCompany)
                .Index(t => t.IdTypeProduct)
                .Index(t => t.IdSocket)
                .Index(t => t.IdTypeMemory)
                .Index(t => t.IdFormFactor);
            
            CreateTable(
                "public.CustomRow",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdCustom = c.Int(),
                        IdProduct = c.Int(),
                        Sum = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Custom", t => t.IdCustom)
                .ForeignKey("public.Product", t => t.IdProduct)
                .Index(t => t.IdCustom)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "public.Custom",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Sum = c.Int(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.User", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "public.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.FormFactor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.ProcurementRow",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdProduct = c.Int(),
                        IdProcurement = c.Int(),
                        Sum = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Procurement", t => t.IdProcurement)
                .ForeignKey("public.Product", t => t.IdProduct)
                .Index(t => t.IdProduct)
                .Index(t => t.IdProcurement);
            
            CreateTable(
                "public.Procurement",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Socket",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.TypeMemory",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.TypeProduct",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Product", "IdCompany", "public.Company");
            DropForeignKey("public.Product", "IdTypeProduct", "public.TypeProduct");
            DropForeignKey("public.Product", "IdTypeMemory", "public.TypeMemory");
            DropForeignKey("public.Product", "IdSocket", "public.Socket");
            DropForeignKey("public.ProcurementRow", "IdProduct", "public.Product");
            DropForeignKey("public.ProcurementRow", "IdProcurement", "public.Procurement");
            DropForeignKey("public.Product", "IdFormFactor", "public.FormFactor");
            DropForeignKey("public.CustomRow", "IdProduct", "public.Product");
            DropForeignKey("public.Custom", "IdUser", "public.User");
            DropForeignKey("public.CustomRow", "IdCustom", "public.Custom");
            DropIndex("public.ProcurementRow", new[] { "IdProcurement" });
            DropIndex("public.ProcurementRow", new[] { "IdProduct" });
            DropIndex("public.Custom", new[] { "IdUser" });
            DropIndex("public.CustomRow", new[] { "IdProduct" });
            DropIndex("public.CustomRow", new[] { "IdCustom" });
            DropIndex("public.Product", new[] { "IdFormFactor" });
            DropIndex("public.Product", new[] { "IdTypeMemory" });
            DropIndex("public.Product", new[] { "IdSocket" });
            DropIndex("public.Product", new[] { "IdTypeProduct" });
            DropIndex("public.Product", new[] { "IdCompany" });
            DropTable("public.TypeProduct");
            DropTable("public.TypeMemory");
            DropTable("public.Socket");
            DropTable("public.Procurement");
            DropTable("public.ProcurementRow");
            DropTable("public.FormFactor");
            DropTable("public.User");
            DropTable("public.Custom");
            DropTable("public.CustomRow");
            DropTable("public.Product");
            DropTable("public.Company");
        }
    }
}
