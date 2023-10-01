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
        }
    }
}
