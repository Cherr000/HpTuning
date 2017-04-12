namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarHistories",
                c => new
                    {
                        carHistoryID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Vin = c.String(),
                        Mile = c.String(),
                        Source = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.carHistoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarHistories");
        }
    }
}
