namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRelationshipUser_UserCredentials : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_Number", "dbo.UserCredentials");
            DropIndex("dbo.Users", new[] { "User_Number" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "User_Number", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "User_Number");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "User_Number", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "User_Number");
            CreateIndex("dbo.Users", "User_Number");
            AddForeignKey("dbo.Users", "User_Number", "dbo.UserCredentials", "UserID");
        }
    }
}
