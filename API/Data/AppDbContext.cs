using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Players> Players { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
