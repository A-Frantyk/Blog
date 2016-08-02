namespace Blog_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolesTable_WithRelationship_withUserstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_User_Number = c.Int(nullable: false),
                        Roles_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_User_Number, t.Roles_RoleID })
                .ForeignKey("dbo.Users", t => t.User_User_Number, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Roles_RoleID, cascadeDelete: true)
                .Index(t => t.User_User_Number)
                .Index(t => t.Roles_RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Roles_RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_User_Number", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "Roles_RoleID" });
            DropIndex("dbo.UserRoles", new[] { "User_User_Number" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
