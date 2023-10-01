using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Configuration
{
    public class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
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
