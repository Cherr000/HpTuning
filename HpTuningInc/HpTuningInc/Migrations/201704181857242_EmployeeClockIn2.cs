namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeClockIn2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EmployeeClockIns");
            AddColumn("dbo.EmployeeClockIns", "ClockID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EmployeeClockIns", "Email", c => c.String());
            AddPrimaryKey("dbo.EmployeeClockIns", "ClockID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EmployeeClockIns");
            AlterColumn("dbo.EmployeeClockIns", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.EmployeeClockIns", "ClockID");
            AddPrimaryKey("dbo.EmployeeClockIns", "Email");
        }
    }
}
