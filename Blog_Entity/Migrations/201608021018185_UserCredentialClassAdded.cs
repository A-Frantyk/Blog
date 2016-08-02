namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCredentialClassAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCredentials",
                c => new
                    {
                        CredentialID = c.Int(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CredentialID)
                .ForeignKey("dbo.Users", t => t.CredentialID)
                .Index(t => t.CredentialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCredentials", "CredentialID", "dbo.Users");
            DropIndex("dbo.UserCredentials", new[] { "CredentialID" });
            DropTable("dbo.UserCredentials");
        }
    }
}
