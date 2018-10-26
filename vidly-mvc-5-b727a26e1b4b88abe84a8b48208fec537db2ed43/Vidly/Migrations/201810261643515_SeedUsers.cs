namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ab6bb09-58fc-4894-9a6c-536b7af71b9c', N'moviesAdmin@vidly.com', 0, N'AED5vXoEoR42t2Wx9H66mdImx626ZGU3dYnrRZF1A4pW1PD1vUIqrHC+ezcUWwIntQ==', N'4a4d0b5c-579b-41bd-9e61-f42869c80954', NULL, 0, 0, NULL, 1, 0, N'moviesAdmin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3bf88e6f-8371-4715-aa5b-8a0ec0adf991', N'guest@vidly.com', 0, N'ANAI4mvC3PwBWGoHdM4sQ8o+BkzcH9ERLrBtrSac/JZFnp3dNSgE29s5jA5CRwbMlg==', N'd84f726c-738f-4db5-82bf-689559be35d2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c217f5a2-6b85-46ac-b4b3-664e675c9432', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1ab6bb09-58fc-4894-9a6c-536b7af71b9c', N'c217f5a2-6b85-46ac-b4b3-664e675c9432')
");
        }

        public override void Down()
        {
        }
    }
}
