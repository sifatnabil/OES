namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStudentExamManyToMany1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentExams", newName: "Attend");
            RenameColumn(table: "dbo.Attend", name: "Student_Id", newName: "StudentId");
            RenameColumn(table: "dbo.Attend", name: "Exam_Id", newName: "ExamId");
            RenameIndex(table: "dbo.Attend", name: "IX_Student_Id", newName: "IX_StudentId");
            RenameIndex(table: "dbo.Attend", name: "IX_Exam_Id", newName: "IX_ExamId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Attend", name: "IX_ExamId", newName: "IX_Exam_Id");
            RenameIndex(table: "dbo.Attend", name: "IX_StudentId", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.Attend", name: "ExamId", newName: "Exam_Id");
            RenameColumn(table: "dbo.Attend", name: "StudentId", newName: "Student_Id");
            RenameTable(name: "dbo.Attend", newName: "StudentExams");
        }
    }
}
