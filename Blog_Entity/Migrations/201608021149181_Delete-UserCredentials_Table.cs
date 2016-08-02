namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUserCredentials_Table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCredentials", "CredentialID", "dbo.Users");
            DropIndex("dbo.UserCredentials", new[] { "CredentialID" });
            DropTable("dbo.UserCredentials");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCredentials",
                c => new
                    {
                        CredentialID = c.Int(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CredentialID);
            
            CreateIndex("dbo.UserCredentials", "CredentialID");
            AddForeignKey("dbo.UserCredentials", "CredentialID", "dbo.Users", "User_Number");
        }
    }
}
