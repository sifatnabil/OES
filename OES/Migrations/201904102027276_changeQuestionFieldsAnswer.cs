namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeQuestionFieldsAnswer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "RightAnswer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "RightAnswer", c => c.String(nullable: false));
        }
    }
}
