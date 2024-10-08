using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    /*
     * Zadanie 1 
    * Zdefiniuj metodę z widokiem Calculator
    * Dodaj link nawigacyjny do tej metody
     * Zadanie 2
     * Dodaj do kalkulatora:
     * Operator pow, który podnosiz x do potęgi y
     * funkcje sin, która oblicza sin(x), y jest zbędna
     * 
    */
    public IActionResult Calculator(string op, double? x, double? y)
    {
       // var op = Request.Query["op"];
       // var x = double.Parse(Request.Query["x"]);
       // var y = double.Parse(Request.Query["y"]);
       if (x is null || y is null)
       {
           ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze x lub y";
           return View("CalculatorError");
       }

       if (op is null)
       {
           ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze x lub y";
           return View("CalculatorError");
       }
       
       switch (op)
       {
          case "add":
              ViewBag.Result = x + y;
              break;
          case "sub":
              ViewBag.Result = x - y;
              break;
          case "mul":
              ViewBag.Result = x * y;
              break;
          case "div":
              ViewBag.Result = x / y;
              break;
          case "pow":
              ViewBag.Result = Math.Pow((double)x,(double)y);
              break;
          case "sin":
              ViewBag.Result = Math.Sin((double)x);
              break;
       }
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div , Pow, Sin
}