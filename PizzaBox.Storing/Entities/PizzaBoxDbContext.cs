using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public class AnimalsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=tcp:pizzaboxapp-nick.database.windows.net,1433;Initial Catalog=PizzaBoxDB-Nick;User ID=dev;Password=<password>");
        }

        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topping>().HasIndex(t => t.ToppingType).IsUnique();
            modelBuilder.Entity<Crust>().HasIndex(c => c.CrustType).IsUnique();
            modelBuilder.Entity<Size>().HasIndex(s => s.SizeType).IsUnique();
            modelBuilder.Entity<Store>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Name).IsUnique();

            // modelBuilder.Entity<Topping>().HasMany(t => t.Pizzas).WithMany(p => p.Toppings);
            modelBuilder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping);
            modelBuilder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza);

            modelBuilder.Entity<Order>().HasOne(o => o.Customer);
            modelBuilder.Entity<Order>().HasOne(o => o.Store);
            modelBuilder.Entity<Order>().HasMany(o => o.Pizzas).WithMany(p => p.Orders);
            base.OnModelCreating(modelBuilder);
        }


    }
}