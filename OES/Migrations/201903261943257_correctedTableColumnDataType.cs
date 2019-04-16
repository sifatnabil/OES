namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedTableColumnDataType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Queries", new[] { "Student_Id" });
            DropColumn("dbo.Queries", "StudentId");
            RenameColumn(table: "dbo.Queries", name: "Student_Id", newName: "StudentId");
            AddColumn("dbo.Queries", "QueryTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "UserId", c => c.String());
            AlterColumn("dbo.Queries", "StudentId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Queries", "StudentId");
            DropColumn("dbo.Queries", "QeueryTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queries", "QeueryTime", c => c.DateTime(nullable: false));
            DropIndex("dbo.Queries", new[] { "StudentId" });
            AlterColumn("dbo.Queries", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Queries", "QueryTime");
            RenameColumn(table: "dbo.Queries", name: "StudentId", newName: "Student_Id");
            AddColumn("dbo.Queries", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Queries", "Student_Id");
        }
    }
}
