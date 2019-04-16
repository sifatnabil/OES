namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrctedStudentColumninResult : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Results", new[] { "Student_Id" });
            DropColumn("dbo.Results", "StudentId");
            RenameColumn(table: "dbo.Results", name: "Student_Id", newName: "StudentId");
            AlterColumn("dbo.Results", "StudentId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Results", "StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Results", new[] { "StudentId" });
            AlterColumn("dbo.Results", "StudentId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Results", name: "StudentId", newName: "Student_Id");
            AddColumn("dbo.Results", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Results", "Student_Id");
        }
    }
}
