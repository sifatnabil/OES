namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTeacherToExam : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Exams", new[] { "TeacherId" });
            AlterColumn("dbo.Exams", "TeacherId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Exams", "TeacherId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Exams", new[] { "TeacherId" });
            AlterColumn("dbo.Exams", "TeacherId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Exams", "TeacherId");
        }
    }
}
