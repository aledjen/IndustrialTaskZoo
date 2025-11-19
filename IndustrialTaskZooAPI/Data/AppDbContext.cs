using IndustrialTaskZooAPI.Models;
using IndustrialTaskZooAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace IndustrialTaskZooAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        // public DbSet<YourEntity> YourEntities => Set<YourEntity>();
        public DbSet<Animal> Animals => Set<Animal>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>().HasData(
            new Animal { Id = 1, Name = "Leo", Species = "Lion", DietType = DietType.Carnivore },
            new Animal { Id = 2, Name = "Mila", Species = "Zebra", DietType = DietType.Herbivore },
            new Animal { Id = 3, Name = "Gigi", Species = "Giraffe", DietType = DietType.Herbivore },
            new Animal { Id = 4, Name = "Rocky", Species = "Tiger", DietType = DietType.Carnivore }
        );

            // Example:
            // modelBuilder.Entity<YourEntity>(entity =>
            // {
            //     entity.Property(x => x.Name)
            //           .IsRequired()
            //           .HasMaxLength(100);
            // });
        }
    }
}
