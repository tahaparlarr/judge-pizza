namespace JudgePizzaApp.Models.Entities;
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte[]? Image { get; set; }
    public List<ProductIngredient> ProductIngredients { get; set; } = new();
}
