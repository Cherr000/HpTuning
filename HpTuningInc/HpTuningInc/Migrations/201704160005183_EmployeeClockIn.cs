namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeClockIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeClockIns",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        ClockIn = c.DateTime(nullable: false),
                        Break = c.DateTime(nullable: false),
                        ClockOut = c.DateTime(nullable: false),
                        Hour = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeClockIns");
        }
    }
}
