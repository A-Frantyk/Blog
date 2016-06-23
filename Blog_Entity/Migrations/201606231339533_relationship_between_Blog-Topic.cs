namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationship_between_BlogTopic : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Topics", "Blog_Number");
            AddForeignKey("dbo.Topics", "Blog_Number", "dbo.Blogs", "Blog_Number", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Blog_Number", "dbo.Blogs");
            DropIndex("dbo.Topics", new[] { "Blog_Number" });
        }
    }
}
