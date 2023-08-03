namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.enrollments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        pid = c.Int(nullable: false),
                        mid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.members", t => t.pid, cascadeDelete: true)
                .ForeignKey("dbo.projects", t => t.mid, cascadeDelete: true)
                .Index(t => t.pid)
                .Index(t => t.mid);
            
            CreateTable(
                "dbo.members",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        status_now = c.String(),
                        created_time = c.DateTime(nullable: false),
                        sid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.supervisors", t => t.sid, cascadeDelete: true)
                .Index(t => t.sid);
            
            CreateTable(
                "dbo.supervisors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.enrollments", "mid", "dbo.projects");
            DropForeignKey("dbo.projects", "sid", "dbo.supervisors");
            DropForeignKey("dbo.enrollments", "pid", "dbo.members");
            DropIndex("dbo.projects", new[] { "sid" });
            DropIndex("dbo.enrollments", new[] { "mid" });
            DropIndex("dbo.enrollments", new[] { "pid" });
            DropTable("dbo.supervisors");
            DropTable("dbo.projects");
            DropTable("dbo.members");
            DropTable("dbo.enrollments");
        }
    }
}
