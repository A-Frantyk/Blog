namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteOneColumnFromUserstable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserCredentialID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserCredentialID", c => c.Int(nullable: false));
        }
    }
}
