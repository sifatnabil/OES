namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodGroupAdditionTry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BloodGroupId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "BloodGroupId");
            AddForeignKey("dbo.AspNetUsers", "BloodGroupId", "dbo.BloodGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.AspNetUsers", new[] { "BloodGroupId" });
            DropColumn("dbo.AspNetUsers", "BloodGroupId");
        }
    }
}
