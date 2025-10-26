using JudgePizzaApp.Models.Configurations;
using JudgePizzaApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JudgePizzaApp.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ProductIngredient> ProductIngredients { get; set; }
}
