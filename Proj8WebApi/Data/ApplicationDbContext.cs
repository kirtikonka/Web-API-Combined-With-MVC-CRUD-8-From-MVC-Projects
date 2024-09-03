using Microsoft.EntityFrameworkCore;
using Proj8WebApi.Models;

namespace Proj8WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Emp> employees { get; set; }
    }
}
