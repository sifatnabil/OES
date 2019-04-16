namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madedatetimenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
