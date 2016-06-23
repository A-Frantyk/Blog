namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables_for_blogDB_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Comment_Number = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        User_Number = c.Int(),
                        Writes_Number = c.Int(),
                    })
                .PrimaryKey(t => t.Comment_Number);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Like_Number = c.Int(nullable: false, identity: true),
                        Like = c.Int(nullable: false),
                        Write_Number = c.Int(),
                        Comment_Number = c.Int(),
                    })
                .PrimaryKey(t => t.Like_Number);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Topic_Number = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1024),
                        Topic_Title = c.String(),
                        Blog_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Topic_Number);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_Number = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Last_Name = c.String(maxLength: 256),
                        Age = c.Int(),
                        Education = c.String(maxLength: 256),
                        Mobile_Phone = c.Int(),
                        Short_Information = c.String(maxLength: 2048),
                        Facebook_Link = c.String(),
                        Vk_Link = c.String(),
                        Mail_Link = c.String(),
                    })
                .PrimaryKey(t => t.User_Number);
            
            CreateTable(
                "dbo.Writes",
                c => new
                    {
                        Write_Number = c.Int(nullable: false, identity: true),
                        Topic_Number = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Time = c.DateTime(),
                    })
                .PrimaryKey(t => t.Write_Number);
            
            AddColumn("dbo.Blogs", "Description", c => c.String(maxLength: 2048));
            AlterColumn("dbo.Blogs", "Author", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Author", c => c.String(maxLength: 256));
            DropColumn("dbo.Blogs", "Description");
            DropTable("dbo.Writes");
            DropTable("dbo.Users");
            DropTable("dbo.Topics");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
        }
    }
}
