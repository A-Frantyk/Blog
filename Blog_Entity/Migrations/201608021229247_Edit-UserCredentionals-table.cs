namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserCredentionalstable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserCredentials");
            AlterColumn("dbo.UserCredentials", "UserID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserCredentials", "UserID");
            DropColumn("dbo.UserCredentials", "CredentialID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserCredentials", "CredentialID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserCredentials");
            AlterColumn("dbo.UserCredentials", "UserID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserCredentials", "CredentialID");
        }
    }
}
