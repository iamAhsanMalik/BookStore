using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        public DbSet<Books> Books { get; set; } = null!;
        public DbSet<Languages> Languages { get; set; } = null!;
        public DbSet<BookGallery> BookGallery { get; set; } = null!;
    }

}
