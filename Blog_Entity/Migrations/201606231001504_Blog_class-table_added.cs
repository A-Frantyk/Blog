namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog_classtable_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Blog_Number = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        Author = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Blog_Number);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blogs");
        }
    }
}
