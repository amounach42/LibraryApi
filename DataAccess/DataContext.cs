using Microsoft.EntityFrameworkCore;
using LibraryApi.Controller;

namespace LibraryApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
    }
}