namespace news_portal_API_task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        date = c.DateTime(nullable: false),
                        description = c.String(),
                        cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.cid, cascadeDelete: true)
                .Index(t => t.cid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news", "cid", "dbo.categories");
            DropIndex("dbo.news", new[] { "cid" });
            DropTable("dbo.news");
            DropTable("dbo.categories");
        }
    }
}
