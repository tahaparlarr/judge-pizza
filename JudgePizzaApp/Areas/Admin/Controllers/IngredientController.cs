using JudgePizzaApp.Data;
using JudgePizzaApp.Models.Entities;
using JudgePizzaApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JudgePizzaApp.Areas.Admin.Controllers;

[Area("Admin")]
public class IngredientController : Controller
{
    private readonly AppDbContext _context;
    public IngredientController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var ingredients = await _context.Ingredients.Select(i => new IngredientViewModel
        {
            Id = i.Id,
            Name = i.Name
        })
      .OrderBy(i => i.Name)
      .ToListAsync();

        var ingredientCount = await _context.Ingredients.CountAsync();
        ViewBag.IngredientCount = ingredientCount;

        return View(ingredients);
    }

    public IActionResult Create()
    {
        return View(new IngredientViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IngredientViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var ingredient = new Ingredient { Name = model.Name };
        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);

        if (ingredient == null)
            return NotFound();

        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);

        if (ingredient == null)
            return NotFound();

        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
