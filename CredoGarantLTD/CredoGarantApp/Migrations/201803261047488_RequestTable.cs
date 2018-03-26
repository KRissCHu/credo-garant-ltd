namespace CredoGarantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        RequestingFirmName = c.String(),
                        LoadingAddress = c.String(nullable: false),
                        LoadingDateTime = c.DateTime(nullable: false),
                        UnloadingAdress = c.String(nullable: false),
                        UnloadingDateTime = c.DateTime(nullable: false),
                        EmailOfContact = c.String(nullable: false),
                        PhoneOfContact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
