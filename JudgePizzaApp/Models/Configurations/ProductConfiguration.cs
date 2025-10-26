using JudgePizzaApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudgePizzaApp.Models.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(60);

        builder.HasMany(p => p.ProductIngredients)
            .WithOne(pi => pi.Product)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
