namespace ECommerceProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFurnitureTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Furnitures");
        }
    }
}
