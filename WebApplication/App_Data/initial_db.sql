IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-Author_Authors]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-Author] DROP CONSTRAINT [FK_Book-Author_Authors]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-Author_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-Author] DROP CONSTRAINT [FK_Book-Author_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-Genre_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-Genre] DROP CONSTRAINT [FK_Book-Genre_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-Genre_Genres]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-Genre] DROP CONSTRAINT [FK_Book-Genre_Genres]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-List_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-List] DROP CONSTRAINT [FK_Book-List_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-List_Lists]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-List] DROP CONSTRAINT [FK_Book-List_Lists]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-Tag_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-Tag] DROP CONSTRAINT [FK_Book-Tag_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Book-Tag_Tags]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Book-Tag] DROP CONSTRAINT [FK_Book-Tag_Tags]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Bookmarks_Collection-Book]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Bookmarks] DROP CONSTRAINT [FK_Bookmarks_Collection-Book]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Collection-Book_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Collection-Book] DROP CONSTRAINT [FK_Collection-Book_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Collection-Book_Collections]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Collection-Book] DROP CONSTRAINT [FK_Collection-Book_Collections]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Collections_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Collections] DROP CONSTRAINT [FK_Collections_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Comments_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Comments] DROP CONSTRAINT [FK_Comments_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Comments_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Comments] DROP CONSTRAINT [FK_Comments_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Contents_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Contents] DROP CONSTRAINT [FK_Contents_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Contents_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Contents] DROP CONSTRAINT [FK_Contents_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Covers_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Covers] DROP CONSTRAINT [FK_Covers_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Files_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Files] DROP CONSTRAINT [FK_Files_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Genres_Genres]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Genres] DROP CONSTRAINT [FK_Genres_Genres]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Likes_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Likes] DROP CONSTRAINT [FK_Likes_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Likes_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Likes] DROP CONSTRAINT [FK_Likes_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Quotes_Collection-Book]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Quotes] DROP CONSTRAINT [FK_Quotes_Collection-Book]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Reviews_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Reviews] DROP CONSTRAINT [FK_Reviews_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Reviews_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Reviews] DROP CONSTRAINT [FK_Reviews_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Screenings_Books]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Screenings] DROP CONSTRAINT [FK_Screenings_Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_User-Role_Roles]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [User-Role] DROP CONSTRAINT [FK_User-Role_Roles]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_User-Role_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [User-Role] DROP CONSTRAINT [FK_User-Role_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_UserProfiles_Users]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [UserProfiles] DROP CONSTRAINT [FK_UserProfiles_Users]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Authors]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Authors]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Book-Author]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Book-Author]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Book-Genre]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Book-Genre]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Book-List]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Book-List]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Book-Tag]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Book-Tag]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Bookmarks]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Bookmarks]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Books]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Books]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Collection-Book]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Collection-Book]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Collections]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Collections]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Comments]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Comments]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Contents]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Contents]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Covers]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Covers]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Files]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Files]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Genres]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Genres]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Likes]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Likes]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Lists]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Lists]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Quotes]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Quotes]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Reviews]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Reviews]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Roles]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Roles]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Screenings]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Screenings]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Tags]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Tags]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[User-Role]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [User-Role]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[UserProfiles]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [UserProfiles]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Users]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Users]
;

CREATE TABLE [Authors]
(
	[AuthorID] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(100) NOT NULL,
	[Birth_Date] datetime,
	[Death_Date] datetime,
	[Biography] ntext,
	[Photo_Path] nvarchar(255)
)
;

CREATE TABLE [Book-Author]
(
	[BookID] int NOT NULL,
	[AuthorID] int NOT NULL
)
;

CREATE TABLE [Book-Genre]
(
	[BookID] int NOT NULL,
	[GenreID] int NOT NULL
)
;

CREATE TABLE [Book-List]
(
	[BookID] int NOT NULL,
	[ListID] int NOT NULL
)
;

CREATE TABLE [Book-Tag]
(
	[BookID] int NOT NULL,
	[TagID] int NOT NULL
)
;

CREATE TABLE [Bookmarks]
(
	[BookmarkID] int NOT NULL IDENTITY (1, 1),
	[Collection_BookID] int NOT NULL,
	[Page] int NOT NULL
)
;

CREATE TABLE [Books]
(
	[BookID] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(200) NOT NULL,
	[First_Publication] datetime2(7),
	[Age_Caegory] int,
	[Confirmed] int NOT NULL
)
;

CREATE TABLE [Collection-Book]
(
	[Collection_BookID] int NOT NULL IDENTITY (1, 1),
	[CollectionID] int NOT NULL,
	[BookID] int NOT NULL,
	[IsRead] bit
)
;

CREATE TABLE [Collections]
(
	[CollectionID] int NOT NULL IDENTITY (1, 1),
	[UserID] int NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Description] nvarchar(300)
)
;

CREATE TABLE [Comments]
(
	[CommentID] int NOT NULL IDENTITY (1, 1),
	[UserID] int NOT NULL,
	[BookID] int NOT NULL,
	[Text] ntext NOT NULL,
	[Added_Date] datetime NOT NULL
)
;

CREATE TABLE [Contents]
(
	[ContentID] int NOT NULL IDENTITY (1, 1),
	[BookID] int NOT NULL,
	[UserID] int NOT NULL,
	[Text] ntext
)
;

CREATE TABLE [Covers]
(
	[CoverID] int NOT NULL IDENTITY (1, 1),
	[BookID] int NOT NULL,
	[Path] nvarchar(255) NOT NULL
)
;

CREATE TABLE [Files]
(
	[FileID] int NOT NULL IDENTITY (1, 1),
	[BookID] int NOT NULL,
	[Path] nvarchar(255) NOT NULL,
	[Format] nvarchar(5) NOT NULL
)
;

CREATE TABLE [Genres]
(
	[GenreID] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL,
	[Parent_GenreID] int
)
;

CREATE TABLE [Likes]
(
	[LikeID] int NOT NULL IDENTITY (1, 1),
	[UserID] int NOT NULL,
	[BookID] int NOT NULL,
	[Like] bit NOT NULL
)
;

CREATE TABLE [Lists]
(
	[ListID] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(100) NOT NULL
)
;

CREATE TABLE [Quotes]
(
	[QuoteID] int NOT NULL IDENTITY (1, 1),
	[Collection_BookID] int NOT NULL,
	[Text] ntext NOT NULL
)
;

CREATE TABLE [Reviews]
(
	[ReviewID] int NOT NULL IDENTITY (1, 1),
	[UserID] int NOT NULL,
	[BookID] int NOT NULL,
	[Header] nvarchar(300) NOT NULL,
	[Text] ntext NOT NULL,
	[Review_Type] int NOT NULL,
	[Added_Date] datetime NOT NULL
)
;

CREATE TABLE [Roles]
(
	[RoleID] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL,
	[Priority] int NOT NULL DEFAULT 0
)
;

CREATE TABLE [Screenings]
(
	[ScreeningID] int NOT NULL IDENTITY (1, 1),
	[BookID] int NOT NULL,
	[Film_Name] nvarchar(200) NOT NULL,
	[Year] datetime NOT NULL,
	[Link] nvarchar(200)
)
;

CREATE TABLE [Tags]
(
	[TagID] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL
)
;

CREATE TABLE [User-Role]
(
	[UserID] int NOT NULL,
	[RoleID] int NOT NULL
)
;

CREATE TABLE [UserProfiles]
(
	[UserID] int NOT NULL,
	[Name] nvarchar(50),
	[Surname] nvarchar(50),
	[Photo_Path] nvarchar(255),
	[Points] int,
	[Level] int
)
;

CREATE TABLE [Users]
(
	[UserID] int NOT NULL IDENTITY (1, 1),
	[Login] nvarchar(64) NOT NULL,
	[Password] nvarchar(128) NOT NULL,
	[Email] nvarchar(64) NOT NULL
)
;

ALTER TABLE [Authors] 
 ADD CONSTRAINT [PK_Authors]
	PRIMARY KEY CLUSTERED ([AuthorID])
;

ALTER TABLE [Book-Author] 
 ADD CONSTRAINT [PK_Book-Author]
	PRIMARY KEY CLUSTERED ([BookID],[AuthorID])
;

ALTER TABLE [Book-Genre] 
 ADD CONSTRAINT [PK_Book-Genre]
	PRIMARY KEY CLUSTERED ([BookID],[GenreID])
;

ALTER TABLE [Book-List] 
 ADD CONSTRAINT [PK_Book-List]
	PRIMARY KEY CLUSTERED ([BookID],[ListID])
;

ALTER TABLE [Book-Tag] 
 ADD CONSTRAINT [PK_Book-Tag]
	PRIMARY KEY CLUSTERED ([BookID],[TagID])
;

ALTER TABLE [Bookmarks] 
 ADD CONSTRAINT [PK_Bookmarks]
	PRIMARY KEY CLUSTERED ([BookmarkID])
;

ALTER TABLE [Books] 
 ADD CONSTRAINT [PK_Books]
	PRIMARY KEY CLUSTERED ([BookID])
;

ALTER TABLE [Collection-Book] 
 ADD CONSTRAINT [PK_Collection-Book]
	PRIMARY KEY CLUSTERED ([Collection_BookID])
;

ALTER TABLE [Collections] 
 ADD CONSTRAINT [PK_Collections]
	PRIMARY KEY CLUSTERED ([CollectionID])
;

ALTER TABLE [Comments] 
 ADD CONSTRAINT [PK_Comments]
	PRIMARY KEY CLUSTERED ([CommentID])
;

ALTER TABLE [Contents] 
 ADD CONSTRAINT [PK_Contents]
	PRIMARY KEY CLUSTERED ([ContentID])
;

ALTER TABLE [Contents] 
 ADD CONSTRAINT [UQ_Content_User_Book] UNIQUE NONCLUSTERED ([UserID],[BookID])
;

ALTER TABLE [Covers] 
 ADD CONSTRAINT [PK_Covers]
	PRIMARY KEY CLUSTERED ([CoverID])
;

ALTER TABLE [Files] 
 ADD CONSTRAINT [PK_Files]
	PRIMARY KEY CLUSTERED ([FileID])
;

ALTER TABLE [Genres] 
 ADD CONSTRAINT [PK_Genres]
	PRIMARY KEY CLUSTERED ([GenreID])
;

ALTER TABLE [Likes] 
 ADD CONSTRAINT [PK_Likes]
	PRIMARY KEY CLUSTERED ([LikeID])
;

ALTER TABLE [Likes] 
 ADD CONSTRAINT [UQ_Like_User_Book] UNIQUE NONCLUSTERED ([UserID],[BookID])
;

ALTER TABLE [Lists] 
 ADD CONSTRAINT [PK_Lists]
	PRIMARY KEY CLUSTERED ([ListID])
;

ALTER TABLE [Quotes] 
 ADD CONSTRAINT [PK_Quotes]
	PRIMARY KEY CLUSTERED ([QuoteID])
;

ALTER TABLE [Reviews] 
 ADD CONSTRAINT [PK_Reviews]
	PRIMARY KEY CLUSTERED ([ReviewID])
;

ALTER TABLE [Reviews] 
 ADD CONSTRAINT [UQ_Review_User_Book] UNIQUE NONCLUSTERED ([UserID],[BookID])
;

ALTER TABLE [Roles] 
 ADD CONSTRAINT [PK_Roles]
	PRIMARY KEY CLUSTERED ([RoleID])
;

ALTER TABLE [Screenings] 
 ADD CONSTRAINT [PK_Screenings]
	PRIMARY KEY CLUSTERED ([ScreeningID])
;

ALTER TABLE [Tags] 
 ADD CONSTRAINT [PK_Tags]
	PRIMARY KEY CLUSTERED ([TagID])
;

ALTER TABLE [User-Role] 
 ADD CONSTRAINT [PK_User-Role]
	PRIMARY KEY CLUSTERED ([UserID],[RoleID])
;

ALTER TABLE [UserProfiles] 
 ADD CONSTRAINT [PK_UserProfiles]
	PRIMARY KEY CLUSTERED ([UserID])
;

ALTER TABLE [Users] 
 ADD CONSTRAINT [PK_Users]
	PRIMARY KEY CLUSTERED ([UserID])
;

ALTER TABLE [Book-Author] ADD CONSTRAINT [FK_Book-Author_Authors]
	FOREIGN KEY ([AuthorID]) REFERENCES [Authors] ([AuthorID]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Book-Author] ADD CONSTRAINT [FK_Book-Author_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Book-Genre] ADD CONSTRAINT [FK_Book-Genre_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Book-Genre] ADD CONSTRAINT [FK_Book-Genre_Genres]
	FOREIGN KEY ([GenreID]) REFERENCES [Genres] ([GenreID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Book-List] ADD CONSTRAINT [FK_Book-List_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Book-List] ADD CONSTRAINT [FK_Book-List_Lists]
	FOREIGN KEY ([ListID]) REFERENCES [Lists] ([ListID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Book-Tag] ADD CONSTRAINT [FK_Book-Tag_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Book-Tag] ADD CONSTRAINT [FK_Book-Tag_Tags]
	FOREIGN KEY ([TagID]) REFERENCES [Tags] ([TagID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Bookmarks] ADD CONSTRAINT [FK_Bookmarks_Collection-Book]
	FOREIGN KEY ([Collection_BookID]) REFERENCES [Collection-Book] ([Collection_BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Collection-Book] ADD CONSTRAINT [FK_Collection-Book_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Collection-Book] ADD CONSTRAINT [FK_Collection-Book_Collections]
	FOREIGN KEY ([CollectionID]) REFERENCES [Collections] ([CollectionID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Collections] ADD CONSTRAINT [FK_Collections_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Comments] ADD CONSTRAINT [FK_Comments_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Contents] ADD CONSTRAINT [FK_Contents_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Contents] ADD CONSTRAINT [FK_Contents_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Covers] ADD CONSTRAINT [FK_Covers_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Files] ADD CONSTRAINT [FK_Files_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Genres] ADD CONSTRAINT [FK_Genres_Genres]
	FOREIGN KEY ([Parent_GenreID]) REFERENCES [Genres] ([GenreID]) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE [Likes] ADD CONSTRAINT [FK_Likes_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Likes] ADD CONSTRAINT [FK_Likes_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Quotes] ADD CONSTRAINT [FK_Quotes_Collection-Book]
	FOREIGN KEY ([Collection_BookID]) REFERENCES [Collection-Book] ([Collection_BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Reviews] ADD CONSTRAINT [FK_Reviews_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Reviews] ADD CONSTRAINT [FK_Reviews_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [Screenings] ADD CONSTRAINT [FK_Screenings_Books]
	FOREIGN KEY ([BookID]) REFERENCES [Books] ([BookID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [User-Role] ADD CONSTRAINT [FK_User-Role_Roles]
	FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleID]) ON DELETE CASCADE ON UPDATE Cascade
;

ALTER TABLE [User-Role] ADD CONSTRAINT [FK_User-Role_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE No Action
;

ALTER TABLE [UserProfiles] ADD CONSTRAINT [FK_UserProfiles_Users]
	FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID]) ON DELETE Cascade ON UPDATE Cascade
;
