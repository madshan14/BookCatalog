
using BookCatalog.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Entities.Data
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }


        //OnModelCreating can be removed if Data is not needed.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mystery" },    
                new Category { Id = 2, Name = "Fantasy" },    
                new Category { Id = 3, Name = "Romance" },    
                new Category { Id = 4, Name = "History" },    
                new Category { Id = 5, Name = "Adventure" }    
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "One Piece", Description = "Japanese Manga", PublishDateUtc =  DateTime.UtcNow },
                new Book { Id = 2, Title = "Titanic", Description = "Romance", PublishDateUtc = DateTime.UtcNow },
                new Book { Id = 3, Title = "Doraemon", Description = "Cartoon", PublishDateUtc = DateTime.UtcNow }
            );
        }
    }
}
