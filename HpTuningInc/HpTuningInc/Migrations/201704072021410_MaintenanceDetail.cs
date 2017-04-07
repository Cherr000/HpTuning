namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaintenanceDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaintenanceDetails",
                c => new
                    {
                        maintenanceDetailID = c.Int(nullable: false, identity: true),
                        Vin = c.String(nullable: false),
                        InDate = c.String(nullable: false),
                        OutDate = c.String(nullable: false),
                        MaintenanceText = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.maintenanceDetailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MaintenanceDetails");
        }
    }
}
