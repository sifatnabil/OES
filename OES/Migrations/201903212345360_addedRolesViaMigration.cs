namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRolesViaMigration : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'1ccac23a-e947-4a51-9d42-8d11859831f6', N'Student', N'ApplicationRole')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'5f353811-5204-45e1-b441-4243074dfe19', N'Moderator', N'ApplicationRole')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'7a2e497c-249b-44b3-ae1f-5ed226e9adce', N'Teacher', N'ApplicationRole')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'88d94b08-6856-49be-b64e-4853bedb5c27', N'Admin', N'ApplicationRole')
");
        }
        
        public override void Down()
        {
        }
    }
}
