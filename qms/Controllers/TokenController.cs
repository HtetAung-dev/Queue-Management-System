using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using qms.Models;

namespace qms.Controllers;

public class TokenController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public TokenController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
