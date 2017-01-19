namespace InetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        UserId = c.Int(nullable: false),
                        Card_Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Depot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Good_Name = c.String(),
                        Provider_Name = c.String(),
                        Depot_Quantity = c.Int(nullable: false),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Good_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Good",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Good_Name = c.String(),
                        Good_Category = c.String(),
                        Good_Measure = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paynment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pur_strings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pur_id = c.Int(nullable: false),
                        Gd_id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Double(nullable: false),
                        Good_Id = c.Int(),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Depot", t => t.Good_Id)
                .ForeignKey("dbo.Purchase", t => t.Purchase_Id)
                .Index(t => t.Good_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Purchase_Date = c.DateTime(nullable: false),
                        Overall_cost = c.Double(nullable: false),
                        Item_number = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pur_strings", "Purchase_Id", "dbo.Purchase");
            DropForeignKey("dbo.Pur_strings", "Good_Id", "dbo.Depot");
            DropIndex("dbo.Pur_strings", new[] { "Purchase_Id" });
            DropIndex("dbo.Pur_strings", new[] { "Good_Id" });
            DropTable("dbo.Purchase");
            DropTable("dbo.Pur_strings");
            DropTable("dbo.Paynment");
            DropTable("dbo.Good");
            DropTable("dbo.Depot");
            DropTable("dbo.Customer");
        }
    }
}
