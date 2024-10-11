namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class token_tabel_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        token_string = c.String(),
                        userrole = c.String(),
                        userid = c.Int(nullable: false),
                        expireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tokens");
        }
    }
}
