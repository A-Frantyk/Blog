namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserCredential_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCredentials",
                c => new
                    {
                        CredentialID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CredentialID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCredentials");
        }
    }
}
