namespace YeniYilKart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kartlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 50),
                        GonderenAd = c.String(nullable: false, maxLength: 30),
                        AliciAd = c.String(nullable: false, maxLength: 50),
                        Mesaj = c.String(nullable: false, maxLength: 400),
                        ResimAd = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kartlar");
        }
    }
}
