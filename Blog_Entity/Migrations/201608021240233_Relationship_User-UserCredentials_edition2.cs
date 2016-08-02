namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship_UserUserCredentials_edition2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "User_Number", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "User_Number");
            CreateIndex("dbo.Users", "User_Number");
            AddForeignKey("dbo.Users", "User_Number", "dbo.UserCredentials", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_Number", "dbo.UserCredentials");
            DropIndex("dbo.Users", new[] { "User_Number" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "User_Number", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "User_Number");
        }
    }
}
