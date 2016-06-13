namespace ORMLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Birth_Date = c.DateTime(),
                        Death_Date = c.DateTime(),
                        Biography = c.String(storeType: "ntext"),
                        Photo_Path = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        First_Publication = c.DateTime(precision: 7, storeType: "datetime2"),
                        Age_Caegory = c.Int(),
                        Confirmed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Collection-Book",
                c => new
                    {
                        Collection_BookID = c.Int(nullable: false, identity: true),
                        CollectionID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        IsRead = c.Boolean(),
                    })
                .PrimaryKey(t => t.Collection_BookID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Collections", t => t.CollectionID, cascadeDelete: true)
                .Index(t => t.CollectionID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Bookmarks",
                c => new
                    {
                        BookmarkID = c.Int(nullable: false, identity: true),
                        Collection_BookID = c.Int(nullable: false),
                        Page = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookmarkID)
                .ForeignKey("dbo.Collection-Book", t => t.Collection_BookID, cascadeDelete: true)
                .Index(t => t.Collection_BookID);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        CollectionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.CollectionID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Added_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Text = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Like = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Header = c.String(nullable: false, maxLength: 300),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Review_Type = c.Int(nullable: false),
                        Added_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Photo_Path = c.String(maxLength: 255),
                        Male = c.Boolean(),
                        BirthDate = c.DateTime(),
                        Points = c.Int(),
                        Level = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        QuoteID = c.Int(nullable: false, identity: true),
                        Collection_BookID = c.Int(nullable: false),
                        Text = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.QuoteID)
                .ForeignKey("dbo.Collection-Book", t => t.Collection_BookID, cascadeDelete: true)
                .Index(t => t.Collection_BookID);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        CoverID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Path = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CoverID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Path = c.String(nullable: false, maxLength: 255),
                        Format = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Parent_GenreID = c.Int(),
                    })
                .PrimaryKey(t => t.GenreID)
                .ForeignKey("dbo.Genres", t => t.Parent_GenreID)
                .Index(t => t.Parent_GenreID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        ScreeningID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Film_Name = c.String(nullable: false, maxLength: 200),
                        Year = c.DateTime(nullable: false),
                        Link = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ScreeningID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.User-Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.UserID })
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Book-Genre",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookID, t.GenreID })
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Book-List",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        ListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookID, t.ListID })
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.Book-Tag",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookID, t.TagID })
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Book-Author",
                c => new
                    {
                        AuthorID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorID, t.BookID })
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book-Author", "BookID", "dbo.Books");
            DropForeignKey("dbo.Book-Author", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Book-Tag", "TagID", "dbo.Tags");
            DropForeignKey("dbo.Book-Tag", "BookID", "dbo.Books");
            DropForeignKey("dbo.Screenings", "BookID", "dbo.Books");
            DropForeignKey("dbo.Book-List", "ListID", "dbo.Lists");
            DropForeignKey("dbo.Book-List", "BookID", "dbo.Books");
            DropForeignKey("dbo.Book-Genre", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Book-Genre", "BookID", "dbo.Books");
            DropForeignKey("dbo.Genres", "Parent_GenreID", "dbo.Genres");
            DropForeignKey("dbo.Files", "BookID", "dbo.Books");
            DropForeignKey("dbo.Covers", "BookID", "dbo.Books");
            DropForeignKey("dbo.Quotes", "Collection_BookID", "dbo.Collection-Book");
            DropForeignKey("dbo.UserProfiles", "UserID", "dbo.Users");
            DropForeignKey("dbo.User-Role", "UserID", "dbo.Users");
            DropForeignKey("dbo.User-Role", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reviews", "BookID", "dbo.Books");
            DropForeignKey("dbo.Likes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Likes", "BookID", "dbo.Books");
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropForeignKey("dbo.Contents", "BookID", "dbo.Books");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "BookID", "dbo.Books");
            DropForeignKey("dbo.Collections", "UserID", "dbo.Users");
            DropForeignKey("dbo.Collection-Book", "CollectionID", "dbo.Collections");
            DropForeignKey("dbo.Collection-Book", "BookID", "dbo.Books");
            DropForeignKey("dbo.Bookmarks", "Collection_BookID", "dbo.Collection-Book");
            DropIndex("dbo.Book-Author", new[] { "BookID" });
            DropIndex("dbo.Book-Author", new[] { "AuthorID" });
            DropIndex("dbo.Book-Tag", new[] { "TagID" });
            DropIndex("dbo.Book-Tag", new[] { "BookID" });
            DropIndex("dbo.Book-List", new[] { "ListID" });
            DropIndex("dbo.Book-List", new[] { "BookID" });
            DropIndex("dbo.Book-Genre", new[] { "GenreID" });
            DropIndex("dbo.Book-Genre", new[] { "BookID" });
            DropIndex("dbo.User-Role", new[] { "UserID" });
            DropIndex("dbo.User-Role", new[] { "RoleID" });
            DropIndex("dbo.Screenings", new[] { "BookID" });
            DropIndex("dbo.Genres", new[] { "Parent_GenreID" });
            DropIndex("dbo.Files", new[] { "BookID" });
            DropIndex("dbo.Covers", new[] { "BookID" });
            DropIndex("dbo.Quotes", new[] { "Collection_BookID" });
            DropIndex("dbo.UserProfiles", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "BookID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.Likes", new[] { "BookID" });
            DropIndex("dbo.Likes", new[] { "UserID" });
            DropIndex("dbo.Contents", new[] { "UserID" });
            DropIndex("dbo.Contents", new[] { "BookID" });
            DropIndex("dbo.Comments", new[] { "BookID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Collections", new[] { "UserID" });
            DropIndex("dbo.Bookmarks", new[] { "Collection_BookID" });
            DropIndex("dbo.Collection-Book", new[] { "BookID" });
            DropIndex("dbo.Collection-Book", new[] { "CollectionID" });
            DropTable("dbo.Book-Author");
            DropTable("dbo.Book-Tag");
            DropTable("dbo.Book-List");
            DropTable("dbo.Book-Genre");
            DropTable("dbo.User-Role");
            DropTable("dbo.Tags");
            DropTable("dbo.Screenings");
            DropTable("dbo.Lists");
            DropTable("dbo.Genres");
            DropTable("dbo.Files");
            DropTable("dbo.Covers");
            DropTable("dbo.Quotes");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Roles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Likes");
            DropTable("dbo.Contents");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Collections");
            DropTable("dbo.Bookmarks");
            DropTable("dbo.Collection-Book");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
