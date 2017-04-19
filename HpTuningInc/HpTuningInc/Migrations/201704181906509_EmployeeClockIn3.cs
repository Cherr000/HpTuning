namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeClockIn3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeClockIns", "ClockIn", c => c.String());
            AlterColumn("dbo.EmployeeClockIns", "ClockOut", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeClockIns", "ClockOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeClockIns", "ClockIn", c => c.DateTime(nullable: false));
        }
    }
}
