namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctenrollmenttable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.enrollments", name: "pid", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.enrollments", name: "mid", newName: "pid");
            RenameColumn(table: "dbo.enrollments", name: "__mig_tmp__0", newName: "mid");
            RenameIndex(table: "dbo.enrollments", name: "IX_mid", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.enrollments", name: "IX_pid", newName: "IX_mid");
            RenameIndex(table: "dbo.enrollments", name: "__mig_tmp__0", newName: "IX_pid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.enrollments", name: "IX_pid", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.enrollments", name: "IX_mid", newName: "IX_pid");
            RenameIndex(table: "dbo.enrollments", name: "__mig_tmp__0", newName: "IX_mid");
            RenameColumn(table: "dbo.enrollments", name: "mid", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.enrollments", name: "pid", newName: "mid");
            RenameColumn(table: "dbo.enrollments", name: "__mig_tmp__0", newName: "pid");
        }
    }
}
