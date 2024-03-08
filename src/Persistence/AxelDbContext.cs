using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AxelDbContext : DbContext
    {
        // public AxelDbContext(DbContextOptionsBuilder optionsBuilder)
        // {

        //     // optionsBuilder.UseSqlite("Data Source=AxelDatabase.db")
        //     // .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //     // .EnableSensitiveDataLogging();
        // }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=AxelDatabase.db")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(b => b.Price)
                .HasPrecision(10,2);

            modelBuilder.Entity<Store>()
            .HasMany(m => m.Products)
            .WithMany(p => p.Stores)
            .UsingEntity<StoreProduct>(
                x => x
                    .HasOne(p => p.Product)
                    .WithMany(p => p.StoreProducts)
                    .HasForeignKey(p => p.ProductId),
                y => y
                    .HasOne(p => p.Store)
                    .WithMany(p => p.StoreProducts)
                    .HasForeignKey(p => p.StoreId),
                
                m => {
                    m.HasKey(t => new {t.ProductId, t.StoreId});
                }
            );


            modelBuilder.Entity<Store>().HasData(GetData());

        }

        private Store[] GetData()
        {

            var store  = new Store {
                Id = Guid.NewGuid(),
                Address = "Av. El Uruguay 452",
                Name = "Tienda de Electrodomesticos"
            };

            var store2  = new Store {
                Id = Guid.NewGuid(),
                Address = "Av. El Paso 100",
                Name = "Tienda de Burguers"
            };


            var list = new List<Store> {
                store,
                store2
            };

            return list.ToArray();
        }


        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}