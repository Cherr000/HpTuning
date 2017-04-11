namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Events1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Email");
        }
    }
}
