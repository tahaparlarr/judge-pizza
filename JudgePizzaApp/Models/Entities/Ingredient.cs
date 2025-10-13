namespace JudgePizzaApp.Models.Entities;
public class Ingredient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public List<ProductIngredient> ProductIngredients { get; set; } = new();
}
