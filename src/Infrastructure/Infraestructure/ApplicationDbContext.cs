using DDD.NET.CORE.DOMAIN.ENTITIES.Car;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DDD.NET.CORE.INFRAESTRUCTURE
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // get the configuration from the app settings
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    //.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", optional: true);
                    .Build();
                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Carro");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Id)
                        .HasColumnName("Id");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Model)
                        .HasColumnName("Modelo");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Name)
                        .HasColumnName("Nombre");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Engine)
                        .HasColumnName("Motor");
            modelBuilder.Entity<Car>().HasKey(vf => new { vf.Id });
        }
    }
}