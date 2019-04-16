namespace OES.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [UserTypeId]) VALUES (N'17fc870f-96a4-49e3-a1af-a18e13a919b1', N'admin@gmail.com', 0, N'AEgQ87B0uhMNV9KlGhP6zh+jiTXAGMwla8p5SPnstlfl44yEsJuFGelgbMMX0qM4pQ==', N'50138bb7-863e-43be-8e58-c25b5c8aacf0', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com', NULL, NULL, 1)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'17fc870f-96a4-49e3-a1af-a18e13a919b1', N'88d94b08-6856-49be-b64e-4853bedb5c27')");
        }
        
        public override void Down()
        {
        }
    }
}
