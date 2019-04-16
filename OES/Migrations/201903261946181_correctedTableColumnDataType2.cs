namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedTableColumnDataType2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "ParentCommentId");
            RenameColumn(table: "dbo.Comments", name: "CommentIt_Id", newName: "ParentCommentId");
            RenameIndex(table: "dbo.Comments", name: "IX_CommentIt_Id", newName: "IX_ParentCommentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_ParentCommentId", newName: "IX_CommentIt_Id");
            RenameColumn(table: "dbo.Comments", name: "ParentCommentId", newName: "CommentIt_Id");
            AddColumn("dbo.Comments", "ParentCommentId", c => c.Int(nullable: false));
        }
    }
}
