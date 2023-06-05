namespace OfficeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestProjectAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RquestProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Budget = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.RquestProjects");
        }
    }
}
