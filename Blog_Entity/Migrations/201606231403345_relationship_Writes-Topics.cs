namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationship_WritesTopics : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Writes", "Topic_Number");
            AddForeignKey("dbo.Writes", "Topic_Number", "dbo.Topics", "Topic_Number", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Writes", "Topic_Number", "dbo.Topics");
            DropIndex("dbo.Writes", new[] { "Topic_Number" });
        }
    }
}
