﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORMLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class project_dbEntities : DbContext
    {
        public project_dbEntities()
            : base("name=project_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Collection_Book> Collection_Book { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
    }
}