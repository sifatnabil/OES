namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesignationTableAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DesignationId", c => c.Int());
            CreateIndex("dbo.Teachers", "DesignationId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropColumn("dbo.Teachers", "DesignationId");
        }
    }
}
