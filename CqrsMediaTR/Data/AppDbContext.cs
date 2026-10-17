using CqrsMediaTR.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediaTR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Note> Notes => Set<Note>();
    }
}
