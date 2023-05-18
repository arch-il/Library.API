using Library.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Database.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
