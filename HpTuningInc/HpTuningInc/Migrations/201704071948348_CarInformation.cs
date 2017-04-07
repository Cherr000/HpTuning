namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInformations",
                c => new
                    {
                        carInformationID = c.Int(nullable: false, identity: true),
                        Vin = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Color = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.carInformationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarInformations");
        }
    }
}
