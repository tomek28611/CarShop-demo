using Microsoft.EntityFrameworkCore;

namespace MyShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
              new Car
              {
                  Id = 1,
                  Brand = "Skoda",
                  Model = "Octavia",
                  Year = 2022,
                  Type = "Sedan",
                  Price = 45000.00m,
                  Color = "Gray",
                  ImageFileName = "1.jpg"
              },
                new Car
                {
                    Id = 2,
                    Brand = "Mercedes",
                    Model = "GLE",
                    Year = 2023,
                    Type = "SUV",
                    Price = 3500000.00m,
                    Color = "White",
                    ImageFileName = "2.jpg"
                },
                new Car
                {
                    Id = 3,
                    Brand = "VW",
                    Model = "Passat",
                    Year = 2022,
                    Type = "Combi",
                    Price = 1100.00m,
                    Color = "Blue",
                    ImageFileName = "3.jpg"
                },
                new Car
                {
                    Id = 4,
                    Brand = "Ford",
                    Model = "Transit",
                    Year = 2023,
                    Type = "Bus",
                    Price = 200000.00m,
                    Color = "White",
                    ImageFileName = "4.jpg"
                }
              
             );
        }
    }
}