using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Storage.Entities;
using System.IO;

namespace Storage.Context
{
    class ApplicationContext: DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Sales_note> Sales_Notes { get; set; }
        public DbSet<Series> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;")
               .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pc => pc.Book)
                .WithMany(p => p.BookAuthors)
                .HasForeignKey(pc => pc.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(pc => pc.Author)
                .WithMany(p => p.BookAuthors)
                .HasForeignKey(pc => pc.AuthorId);
        }

    }
}
