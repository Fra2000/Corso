using Microsoft.EntityFrameworkCore;
using PizzeriaWebApp.Models;

namespace PizzeriaWebApp.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientProduct",
                    ip => ip.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientsId").OnDelete(DeleteBehavior.Cascade),
                    ip => ip.HasOne<Product>().WithMany().HasForeignKey("ProductsId").OnDelete(DeleteBehavior.Cascade)
                );
        }
    }
}
