namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship_UserUserCredentials_edition4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserCredentials_UserID", c => c.Int());
            AlterColumn("dbo.Users", "UserCredentialID", c => c.Int(nullable: true));
            CreateIndex("dbo.Users", "UserCredentials_UserID");
            AddForeignKey("dbo.Users", "UserCredentials_UserID", "dbo.UserCredentials", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserCredentials_UserID", "dbo.UserCredentials");
            DropIndex("dbo.Users", new[] { "UserCredentials_UserID" });
            AlterColumn("dbo.Users", "UserCredentialID", c => c.Int());
            DropColumn("dbo.Users", "UserCredentials_UserID");
        }
    }
}
