namespace Simbirsoft1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameDate = c.DateTime(nullable: false),
                        Winner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameInfoes");
        }
    }
}
