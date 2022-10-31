using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FMI.Gateways.Data.Entities;
using System;

namespace FMI.Gateways.Data.Contexts
{
    public class GatewaysContext : DbContext
    {
        public GatewaysContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<PeripheralDevice> PeripheralDevices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true)
               .Build();

            optionsBuilder.UseSqlServer(config["ConnectionString:Gateways"]);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Gateway>()
                .HasIndex(u => u.SerialNumber)
                .IsUnique();
        }
    }
}