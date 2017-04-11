namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerCarInput : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCarInputs",
                c => new
                    {
                        customerCarInfoID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Vin = c.String(),
                        Year = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.customerCarInfoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerCarInputs");
        }
    }
}
