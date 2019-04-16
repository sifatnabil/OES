namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesApply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Birthdate");
        }
    }
}
