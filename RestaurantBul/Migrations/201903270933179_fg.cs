namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ApplicationUser_Id");
            AddForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int());
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Comments", "ApplicationUser_Id");
        }
    }
}
