namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRelationship_betweentablesUser_UserCredentials : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCredentials", "UserID", "dbo.Users");
            DropIndex("dbo.UserCredentials", new[] { "UserID" });
            DropPrimaryKey("dbo.UserCredentials");
            AlterColumn("dbo.UserCredentials", "UserID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserCredentials", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserCredentials");
            AlterColumn("dbo.UserCredentials", "UserID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserCredentials", "UserID");
            CreateIndex("dbo.UserCredentials", "UserID");
            AddForeignKey("dbo.UserCredentials", "UserID", "dbo.Users", "User_Number");
        }
    }
}
