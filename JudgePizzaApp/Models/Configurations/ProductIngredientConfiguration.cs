using JudgePizzaApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudgePizzaApp.Models.Configurations;

public class ProductIngredientConfiguration : IEntityTypeConfiguration<ProductIngredient>
{
    public void Configure(EntityTypeBuilder<ProductIngredient> builder)
    {
        builder.ToTable("ProductIngredient");

        builder.HasKey(pi => new { pi.ProductId, pi.IngredientId });
    }
}
