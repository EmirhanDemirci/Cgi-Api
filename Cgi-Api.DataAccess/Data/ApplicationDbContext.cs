using Cgi_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Cgi_Api.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Incident> Incident { get; set; }
    }
}
