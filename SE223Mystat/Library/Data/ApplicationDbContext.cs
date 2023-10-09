using Library.Configuration;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                    new Author
                    {
                        Id = 1,
                        FirstName = "ილია",
                        LastName = "ჭავჭავაძე",
                        DateOfBirth = new DateTime(1792, 2, 21),
                        DateOfDeath = new DateTime(1902, 10, 22)
                    },
                    new Author
                    {
                        Id = 2,
                        FirstName = "ვაჟა",
                        LastName = "ფშაველა",
                        DateOfBirth = new DateTime(1812, 2, 21),
                        DateOfDeath = new DateTime(1917, 10, 22)
                    },
                    new Author
                    {
                        Id = 3,
                        FirstName = "შოთა",
                        LastName = "რუსთაველი",
                        DateOfBirth = null,
                        DateOfDeath = null
                    }
                );

            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        Title = "TEST # 1",
                        Description = null,
                        Quantity = 10
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "TEST # 2",
                        Description = null,
                        Quantity = 10
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "TEST # 3",
                        Description = null,
                        Quantity = 10
                    }
                );


            modelBuilder.Entity<BookAuthor>().HasData(
                    new BookAuthor { Id = 1, AuthorId = 1, BookId = 1 },
                    new BookAuthor { Id = 2, AuthorId = 2, BookId = 2 },
                    new BookAuthor { Id = 3, AuthorId = 3, BookId = 3 }
                );

        }
    }
}
