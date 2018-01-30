namespace JorgeMencoMedellinTimesBackend.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 200),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Advertisings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 250),
                        Descriotion = c.String(maxLength: 500),
                        PathImage = c.String(maxLength: 250),
                        DateCreation = c.DateTime(nullable: false),
                        Admin_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Adress = c.String(maxLength: 250),
                        admin_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.admin_Id)
                .Index(t => t.admin_Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 250),
                        Subtitle = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        DatePublish = c.DateTime(nullable: false),
                        admin_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.admin_Id)
                .Index(t => t.admin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Events", "admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Advertisings", "Admin_Id", "dbo.Admins");
            DropIndex("dbo.News", new[] { "admin_Id" });
            DropIndex("dbo.Events", new[] { "admin_Id" });
            DropIndex("dbo.Advertisings", new[] { "Admin_Id" });
            DropTable("dbo.News");
            DropTable("dbo.Events");
            DropTable("dbo.Advertisings");
            DropTable("dbo.Admins");
        }
    }
}
