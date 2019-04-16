namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examTableUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "TotalMarks", c => c.Int());
            AlterColumn("dbo.Exams", "NoOfQuestions", c => c.Int());
            AlterColumn("dbo.Exams", "StartingIndex", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "StartingIndex", c => c.Int(nullable: false));
            AlterColumn("dbo.Exams", "NoOfQuestions", c => c.Int(nullable: false));
            AlterColumn("dbo.Exams", "TotalMarks", c => c.Int(nullable: false));
        }
    }
}
