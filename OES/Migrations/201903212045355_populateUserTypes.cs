namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateUserTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserTypes(TypeName) VALUES('Teacher') ");
            Sql("INSERT INTO UserTypes(TypeName) VALUES('Student') ");

        }
        
        public override void Down()
        {
        }
    }
}
