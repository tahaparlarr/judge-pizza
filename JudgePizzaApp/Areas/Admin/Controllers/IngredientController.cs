using Microsoft.AspNetCore.Mvc;

namespace JudgePizzaApp.Areas.Admin.Controllers;
[Area("Admin")]

public class IngredientController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
