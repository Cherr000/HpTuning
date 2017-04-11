namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarInformation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarInformations", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarInformations", "Email");
        }
    }
}
