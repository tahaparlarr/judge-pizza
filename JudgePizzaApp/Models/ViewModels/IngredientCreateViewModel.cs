using System.ComponentModel.DataAnnotations;

namespace JudgePizzaApp.Models.ViewModels;
public class IngredientCreateViewModel
{
    [Required(ErrorMessage = "Malzeme adı boş olamaz")]
    public string Name { get; set; }
}
