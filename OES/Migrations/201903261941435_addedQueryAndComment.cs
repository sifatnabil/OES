namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedQueryAndComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QueryId = c.Int(nullable: false),
                        ParentCommentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserComment = c.String(),
                        CommentTime = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        CommentIt_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Comments", t => t.CommentIt_Id)
                .ForeignKey("dbo.Queries", t => t.QueryId, cascadeDelete: true)
                .Index(t => t.QueryId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.CommentIt_Id);
            
            CreateTable(
                "dbo.Queries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        QueryQues = c.String(),
                        QeueryTime = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.Comments", "QueryId", "dbo.Queries");
            DropForeignKey("dbo.Comments", "CommentIt_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Queries", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Queries", "ExamId", "dbo.Exams");
            DropIndex("dbo.Queries", new[] { "Student_Id" });
            DropIndex("dbo.Queries", new[] { "ExamId" });
            DropIndex("dbo.Comments", new[] { "CommentIt_Id" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comments", new[] { "QueryId" });
            DropTable("dbo.Queries");
            DropTable("dbo.Comments");
        }
    }
}
