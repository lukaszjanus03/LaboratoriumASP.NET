using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;


namespace WebApp.Controllers;

public class CalculatorController : Controller

{
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
    public IActionResult Form()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Calculator(Operators op, double? x, double? y)
    {
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // var y = double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze x lub y";
            return View("CalculatorError");
        }

        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze x lub y";
            return View("CalculatorError");
        }

        switch (op)
        {
            case Operators.Add:
                ViewBag.Result = x + y;
                break;
            case Operators.Sub:
                ViewBag.Result = x - y;
                break;
            case Operators.Mul:
                ViewBag.Result = x * y;
                break;
            case Operators.Div:
                ViewBag.Result = x / y;
                break;
            case Operators.Pow:
                ViewBag.Result = Math.Pow((double)x, (double)y);
                break;
            case Operators.Sin:
                ViewBag.Result = Math.Sin((double)x);
                break;
        }

        return View();
    }

    public enum Operators
    {
        Add, Sub, Mul, Div, Pow, Sin
    }
}
