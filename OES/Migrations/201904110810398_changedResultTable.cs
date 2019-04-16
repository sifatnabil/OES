namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedResultTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "TotalRightAnswer", c => c.Int());
            AlterColumn("dbo.Results", "TotalWrongAnswer", c => c.Int());
            AlterColumn("dbo.Results", "IsOnline", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Results", "IsOnline", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Results", "TotalWrongAnswer", c => c.Int(nullable: false));
            AlterColumn("dbo.Results", "TotalRightAnswer", c => c.Int(nullable: false));
        }
    }
}
