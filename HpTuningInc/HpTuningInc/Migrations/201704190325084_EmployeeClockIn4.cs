namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeClockIn4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeClockIns", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeClockIns", "Date");
        }
    }
}
