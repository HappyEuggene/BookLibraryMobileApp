using Microsoft.EntityFrameworkCore;
using BookLibraryMobileApp.Models;

namespace BookLibraryMobileApp.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\123;Database=BookLibraryDB;Trusted_Connection=True;");
        }
    }
}
