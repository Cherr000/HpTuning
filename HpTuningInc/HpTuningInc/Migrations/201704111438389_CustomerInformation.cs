namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInformations",
                c => new
                    {
                        customerInfoID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.customerInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerInformations");
        }
    }
}
