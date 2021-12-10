namespace FA.JustBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id_post = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 255),
                        desShort = c.String(),
                        content = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        id_user = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_post)
                .ForeignKey("dbo.Users", t => t.id_user, cascadeDelete: true)
                .Index(t => t.id_user);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id_user = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 255),
                        fullName = c.String(maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_user);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "id_user", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "id_user" });
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
