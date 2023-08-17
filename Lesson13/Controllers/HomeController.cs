using System.Collections.Generic;
using System.Diagnostics;
using Lesson13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lesson13.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static List<Product> _products => ProductController.Products;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string firstname, string lastname, string gender)
    {
        var model = new IndexModel
        {
            Products = _products
        };
        return View(model);
    }

    [HttpPost("create-product")]
    public IActionResult CreateProduct([FromForm]Product newProduct)
    {
        _products.Add(newProduct);
        return RedirectToAction("Index");
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