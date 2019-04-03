namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentPoint", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentPoint", c => c.String());
        }
    }
}
