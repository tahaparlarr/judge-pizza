using JudgePizzaApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JudgePizzaApp.Models.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredient");

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.HasMany(i => i.ProductIngredients)
                   .WithOne(pi => pi.Ingredient)
                   .HasForeignKey(pi => pi.IngredientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
