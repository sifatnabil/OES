namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedExamandCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        CourseType = c.String(),
                        CourseCredit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                        TotalMarks = c.Int(nullable: false),
                        ExamName = c.String(),
                        ExamDate = c.DateTime(nullable: false),
                        IsOnline = c.Boolean(nullable: false),
                        IsCatagorized = c.Boolean(nullable: false),
                        NoOfQuestions = c.Int(nullable: false),
                        StartingIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropIndex("dbo.Exams", new[] { "TeacherId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
        }
    }
}
