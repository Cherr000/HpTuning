namespace HpTuningInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        informationID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.informationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
