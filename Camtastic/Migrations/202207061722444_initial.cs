namespace Camtastic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        brand = c.String(),
                        model = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        rating = c.Int(nullable: false),
                        cameraID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cameras", t => t.cameraID)
                .Index(t => t.cameraID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "cameraID", "dbo.Cameras");
            DropIndex("dbo.Photos", new[] { "cameraID" });
            DropTable("dbo.Photos");
            DropTable("dbo.Cameras");
        }
    }
}
