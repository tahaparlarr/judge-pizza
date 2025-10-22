using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JudgePizzaApp.Models;

namespace JudgePizzaApp.Controllers;

public class HomeController : Controller
{
    public HomeController(){}

    public IActionResult Index()
    {
        return View();
    }

}
