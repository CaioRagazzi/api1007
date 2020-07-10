using Microsoft.EntityFrameworkCore;
using OpenOS.Models;

namespace OpenOS.Data
{
    public class OpenOSContext : DbContext
    {
        public OpenOSContext(DbContextOptions<OpenOSContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
