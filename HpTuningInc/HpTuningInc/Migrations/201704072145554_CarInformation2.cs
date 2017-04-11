namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarInformation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarInformations", "Year", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarInformations", "Year");
        }
    }
}
