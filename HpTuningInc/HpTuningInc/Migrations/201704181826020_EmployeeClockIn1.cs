namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeClockIn1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EmployeeClockIns", "Break");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeClockIns", "Break", c => c.DateTime(nullable: false));
        }
    }
}
