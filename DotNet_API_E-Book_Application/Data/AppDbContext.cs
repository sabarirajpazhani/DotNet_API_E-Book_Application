using DotNet_API_E_Book_Application.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_E_Book_Application.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }

}
