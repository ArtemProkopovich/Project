namespace ORMLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DataBaseModel")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Bookmarks> Bookmarks { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Collection_Book> Collection_Book { get; set; }
        public virtual DbSet<Collections> Collections { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Covers> Covers { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Lists> Lists { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Screenings> Screenings { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("Book-Author").MapLeftKey("AuthorID").MapRightKey("BookID"));

            modelBuilder.Entity<Books>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("Book-Genre").MapLeftKey("BookID").MapRightKey("GenreID"));

            modelBuilder.Entity<Books>()
                .HasMany(e => e.Lists)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("Book-List").MapLeftKey("BookID").MapRightKey("ListID"));

            modelBuilder.Entity<Books>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("Book-Tag").MapLeftKey("BookID").MapRightKey("TagID"));

            modelBuilder.Entity<Genres>()
                .HasMany(e => e.Genres1)
                .WithOptional(e => e.Genres2)
                .HasForeignKey(e => e.Parent_GenreID);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("User-Role").MapLeftKey("RoleID").MapRightKey("UserID"));

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.UserProfiles)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete();
        }
    }
}
