using GQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Drink>()
                .HasMany(d => d.Ingredients)
                .WithOne(i => i.Drink!)
                .HasForeignKey(i => i.DrinkId);

            modelBuilder
                .Entity<Ingredient>()
                .HasOne(i => i.Drink)
                .WithMany(d => d.Ingredients)
                .HasForeignKey(i => i.DrinkId);
        }
    }
}
