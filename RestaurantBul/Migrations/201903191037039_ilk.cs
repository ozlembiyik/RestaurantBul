namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AdditionalPlaces", "PlaceId");
            CreateIndex("dbo.AdditionalPlaces", "AdditionalId");
            AddForeignKey("dbo.AdditionalPlaces", "AdditionalId", "dbo.Additionals", "AdditionalId", cascadeDelete: true);
            AddForeignKey("dbo.AdditionalPlaces", "PlaceId", "dbo.Places", "PlaceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalPlaces", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.AdditionalPlaces", "AdditionalId", "dbo.Additionals");
            DropIndex("dbo.AdditionalPlaces", new[] { "AdditionalId" });
            DropIndex("dbo.AdditionalPlaces", new[] { "PlaceId" });
        }
    }
}
