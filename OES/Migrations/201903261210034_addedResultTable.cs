namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedResultTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        TotalRightAnswer = c.Int(nullable: false),
                        TotalWrongAnswer = c.Int(nullable: false),
                        ObtainedMark = c.Int(nullable: false),
                        IsOnline = c.Boolean(nullable: false),
                        Student_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.ExamId)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Results", "ExamId", "dbo.Exams");
            DropIndex("dbo.Results", new[] { "Student_Id" });
            DropIndex("dbo.Results", new[] { "ExamId" });
            DropTable("dbo.Results");
        }
    }
}
