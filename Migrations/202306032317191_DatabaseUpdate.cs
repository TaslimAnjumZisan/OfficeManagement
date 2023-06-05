namespace OfficeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "AdminId", "dbo.Admins");
            DropIndex("dbo.Employees", new[] { "AdminId" });
            DropColumn("dbo.Employees", "AdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "AdminId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "AdminId");
            AddForeignKey("dbo.Employees", "AdminId", "dbo.Admins", "Id", cascadeDelete: true);
        }
    }
}
