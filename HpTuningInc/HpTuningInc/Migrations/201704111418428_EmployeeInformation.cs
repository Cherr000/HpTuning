namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInformations",
                c => new
                    {
                        EmployeeInfoID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeInformations");
        }
    }
}
