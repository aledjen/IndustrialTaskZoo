using IndustrialTaskZooAPI.Data;
using IndustrialTaskZooAPI.Data.Repositories.Animals;
using IndustrialTaskZooAPI.Data.Repositories.Food;
using IndustrialTaskZooAPI.Feeding;
using IndustrialTaskZooAPI.Models;
using IndustrialTaskZooAPI.Models.Enums;
using IndustrialTaskZooAPI.Services.Animals;
using IndustrialTaskZooAPI.Services.Foods;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//DB Configuration
var connectionString = builder.Configuration.GetConnectionString("IndustrialTaskConnection");
var useInMemory = builder.Configuration.GetValue<bool>("UseInMemory");
if (useInMemory)
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("IndustrialZooTaskDb"));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));
}
// Add services to the container.
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddSingleton<IFoodStockRepository, FoodStockRepository>();

builder.Services.AddSingleton<IFeedingStrategyFactory, FeedingStrategyFactory>();

builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IFoodStockService,FoodStockService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Animals.Any())
    {
        db.Animals.AddRange(
            new Animal { Id = 1, Name = "Leo", Species = "Lion", DietType = DietType.Carnivore },
            new Animal { Id = 2, Name = "Mila", Species = "Zebra", DietType = DietType.Herbivore },
            new Animal { Id = 3, Name = "Gigi", Species = "Giraffe", DietType = DietType.Herbivore },
            new Animal { Id = 4, Name = "Rocky", Species = "Tiger", DietType = DietType.Carnivore }
        );

        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
