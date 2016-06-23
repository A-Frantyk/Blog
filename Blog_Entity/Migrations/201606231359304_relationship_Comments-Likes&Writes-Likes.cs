namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationship_CommentsLikesWritesLikes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Likes", "Write_Number");
            CreateIndex("dbo.Likes", "Comment_Number");
            AddForeignKey("dbo.Likes", "Comment_Number", "dbo.Comments", "Comment_Number");
            AddForeignKey("dbo.Likes", "Write_Number", "dbo.Writes", "Write_Number");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Write_Number", "dbo.Writes");
            DropForeignKey("dbo.Likes", "Comment_Number", "dbo.Comments");
            DropIndex("dbo.Likes", new[] { "Comment_Number" });
            DropIndex("dbo.Likes", new[] { "Write_Number" });
        }
    }
}
