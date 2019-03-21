namespace RestaurantBul.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalPlaces",
                c => new
                    {
                        AdditionalPlaceId = c.Int(nullable: false, identity: true),
                        PlaceId = c.Int(nullable: false),
                        AdditionalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionalPlaceId)
                .ForeignKey("dbo.Additionals", t => t.AdditionalId, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId)
                .Index(t => t.AdditionalId);
            
            CreateTable(
                "dbo.Additionals",
                c => new
                    {
                        AdditionalId = c.Int(nullable: false, identity: true),
                        Otopark = c.Boolean(nullable: false),
                        DenizKenari = c.Boolean(nullable: false),
                        DisMekan = c.Boolean(nullable: false),
                        İcMekan = c.Boolean(nullable: false),
                        TerasiVar = c.Boolean(nullable: false),
                        AlkolServis = c.Boolean(nullable: false),
                        Wifi = c.Boolean(nullable: false),
                        OnlineRezervasyon = c.Boolean(nullable: false),
                        Kahvalti = c.Boolean(nullable: false),
                        GelAl = c.Boolean(nullable: false),
                        HayvanDostu = c.Boolean(nullable: false),
                        SigaraAlanı = c.Boolean(nullable: false),
                        PaketServis = c.Boolean(nullable: false),
                        TatlivePasta = c.Boolean(nullable: false),
                        CanliMuzik = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionalId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        PlaceName = c.String(),
                        CategoryName = c.Int(nullable: false),
                        MenuPic = c.String(),
                        Phone = c.String(),
                        Adress = c.String(),
                        County = c.String(),
                        City = c.String(),
                        OpenTime = c.String(),
                        CloseTime = c.String(),
                        AvgPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        CommentPhoto = c.String(),
                        CommentPoint = c.String(),
                        UserId = c.Int(),
                        PlaceId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Places", t => t.PlaceId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.PlaceId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.AdditionalPlaces", "PlaceId", "dbo.Places");
            DropForeignKey("dbo.AdditionalPlaces", "AdditionalId", "dbo.Additionals");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "PlaceId" });
            DropIndex("dbo.AdditionalPlaces", new[] { "AdditionalId" });
            DropIndex("dbo.AdditionalPlaces", new[] { "PlaceId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Places");
            DropTable("dbo.Additionals");
            DropTable("dbo.AdditionalPlaces");
        }
    }
}
