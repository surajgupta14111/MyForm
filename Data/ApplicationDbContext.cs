using Microsoft.EntityFrameworkCore;
using UserForm.Models;

namespace UserForm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Person model ke liye DbSet

        public DbSet<Persons> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // EF default pluralization (People) ko override karke Person table use karega
            modelBuilder.Entity<Persons>().ToTable("Persons");

            base.OnModelCreating(modelBuilder);
        }
    }
}
