using Library.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Author>().HasData(
                    new Author
                    {
                        Id = 1,
                        FirstName = "ილია",
                        LastName = "ჭავჭავაძე",
                        ImageUrl = null,
                        DateOfBirth = new DateTime(1792, 2, 21),
                        DateOfDeath = new DateTime(1902, 10, 22)
                    },
                    new Author
                    {
                        Id = 2,
                        FirstName = "ვაჟა",
                        LastName = "ფშაველა",
                        ImageUrl = null,
                        DateOfBirth = new DateTime(1812, 2, 21),
                        DateOfDeath = new DateTime(1917, 10, 22)
                    },
                    new Author
                    {
                        Id = 3,
                        FirstName = "შოთა",
                        LastName = "რუსთაველი",
                        ImageUrl = null,
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


            modelBuilder.Entity<Department>().HasData(
                    new Department { Id = 1, Name = "Service", Salary = 1500 },
                    new Department { Id = 2, Name = "Marketing", Salary = 2500 },
                    new Department { Id = 3, Name = "IT", Salary = 3500 },
                    new Department { Id = 4, Name = "Administration", Salary = 4500 }
                );


            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Tamta",
                        LastName = "Grigolia",
                        Email = "tamta@gmail.com",
                        PhoneNumber = "555332211",
                        Pin = "01024085082",
                        DepartmentId = 3
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Archil",
                        LastName = "Menabde",
                        Email = "archil@gmail.com",
                        PhoneNumber = "595332211",
                        Pin = "01024085092",
                        DepartmentId = 3
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Saba",
                        LastName = "Gurgenidze",
                        Email = "saba@gmail.com",
                        PhoneNumber = "553332211",
                        Pin = "11024085092",
                        DepartmentId = 2
                    },
                    new Employee
                    {
                        Id = 4,
                        FirstName = "Nika",
                        LastName = "Chkhartishvili",
                        Email = "nika.chkhartishvili7@gmail.com",
                        PhoneNumber = "555337681",
                        Pin = "01024085083",
                        DepartmentId = 4
                    }
                );

            modelBuilder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },

                    new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Customer",
                        NormalizedName = "CUSTOMER"
                    }
                );

        }
    }
}
