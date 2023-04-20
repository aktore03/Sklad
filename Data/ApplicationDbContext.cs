using Microsoft.EntityFrameworkCore;
using Sklad.Models;

namespace Sklad.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Recipients> Recipients { get; set; }
        public DbSet<Write_offs> Write_offs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipients>()
                .HasOne(s => s.Storage)
                .WithMany(r => r.Recipients)
                .HasForeignKey(s => s.StorageId);
        }
    }
}
