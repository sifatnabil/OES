namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserTypeId");
            AddForeignKey("dbo.AspNetUsers", "UserTypeId", "dbo.UserTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.AspNetUsers", new[] { "UserTypeId" });
            DropColumn("dbo.AspNetUsers", "UserTypeId");
            DropTable("dbo.UserTypes");
        }
    }
}
