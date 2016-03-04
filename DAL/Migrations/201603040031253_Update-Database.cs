namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footwears",
                c => new
                    {
                        FootwearId = c.Int(nullable: false, identity: true),
                        FootwearValue = c.String(),
                        MadeBy = c.String(),
                        Size = c.Int(nullable: false),
                        FootwearTypeId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FootwearId)
                .ForeignKey("dbo.FootwearTypes", t => t.FootwearTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .Index(t => t.FootwearTypeId)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.FootwearTypes",
                c => new
                    {
                        FootwearTypeId = c.Int(nullable: false, identity: true),
                        FootwearTypeValue = c.String(),
                        FootwearType_FootwearTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.FootwearTypeId)
                .ForeignKey("dbo.FootwearTypes", t => t.FootwearType_FootwearTypeId)
                .Index(t => t.FootwearType_FootwearTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Footwears", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Footwears", "FootwearTypeId", "dbo.FootwearTypes");
            DropForeignKey("dbo.FootwearTypes", "FootwearType_FootwearTypeId", "dbo.FootwearTypes");
            DropIndex("dbo.FootwearTypes", new[] { "FootwearType_FootwearTypeId" });
            DropIndex("dbo.Footwears", new[] { "InventoryId" });
            DropIndex("dbo.Footwears", new[] { "FootwearTypeId" });
            DropTable("dbo.FootwearTypes");
            DropTable("dbo.Footwears");
        }
    }
}
