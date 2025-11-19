using IndustrialTaskZooAPI.Data;
using IndustrialTaskZooAPI.Data.Repositories.Animals;
using IndustrialTaskZooAPI.Models;
using IndustrialTaskZooAPI.Models.Enums;
using IndustrialTaskZooAPI.Services.Animals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialTaskZooAPI.Tests
{
    public class AnimalServiceTests
    {
        private void SeedAnimals(AppDbContext db)
        {
            db.Animals.AddRange(
                new Animal { Id = 1, Name = "Leo", Species = "Lion", DietType = DietType.Carnivore },
                new Animal { Id = 2, Name = "Mila", Species = "Zebra", DietType = DietType.Herbivore },
                new Animal { Id = 3, Name = "Gigi", Species = "Giraffe", DietType = DietType.Herbivore }
            );

            db.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllAnimals()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new AppDbContext(options);
            SeedAnimals(db);

            var repo = new AnimalRepository(db);
            var service = new AnimalService(repo);

            var result = await service.GetAllAsync();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetAllAsync_FilterBySpecies_ReturnsOnlyMatching()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new AppDbContext(options);
            SeedAnimals(db);

            var repo = new AnimalRepository(db);
            var service = new AnimalService(repo);

            var result = await service.GetAllAsync("Lion");

            Assert.Single(result);
            Assert.Equal("Lion", result.First().Species);
        }

        [Fact]
        public async Task GetAllAsync_FilterNonExisting_ReturnsEmpty()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new AppDbContext(options);
            SeedAnimals(db);

            var repo = new AnimalRepository(db);
            var service = new AnimalService(repo);

            var result = await service.GetAllAsync("Dragon");

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllAsync_FilterCaseInsensitive_ReturnsMatch()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var db = new AppDbContext(options);
            SeedAnimals(db);


            var repo = new AnimalRepository(db);
            var service = new AnimalService(repo);

            var result = await service.GetAllAsync("lion");

            Assert.Single(result);
            Assert.Equal("Lion", result.First().Species);
        }



    }
}
