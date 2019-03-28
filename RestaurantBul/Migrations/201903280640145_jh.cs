namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "User_Id");
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int());
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
