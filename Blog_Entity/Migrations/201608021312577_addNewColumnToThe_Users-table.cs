namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewColumnToThe_Userstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserCredentialID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserCredentialID");
        }
    }
}
