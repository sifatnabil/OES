namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStudentExamManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        Student_Id = c.String(nullable: false, maxLength: 128),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Exam_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exam_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Exam_Id);
            
            AddColumn("dbo.Students", "Question_Id", c => c.Int());
            CreateIndex("dbo.Students", "Question_Id");
            AddForeignKey("dbo.Students", "Question_Id", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.StudentExams", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.StudentExams", "Student_Id", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Question_Id" });
            DropIndex("dbo.StudentExams", new[] { "Exam_Id" });
            DropIndex("dbo.StudentExams", new[] { "Student_Id" });
            DropColumn("dbo.Students", "Question_Id");
            DropTable("dbo.StudentExams");
        }
    }
}
