using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using qms.Models;
using qms.DataAccess;

namespace qms.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Token counters = new Token();
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        Token nextToken = new Token();

        nextToken = tokenSqlMgr.GetFirstToken();
    
        Dictionary<int, String> tickets = new Dictionary<int, String>();
        for(int i = 1; i < 6; i++)
        {
            counters = tokenSqlMgr.GetCounterToken(i);
            if(counters.Qid > 0)
            {
                tickets.Add(i, counters.Ticket);
            }
            else
            {
                tickets.Add(i, "----");
            }
        }

        if(nextToken.Qid > 0)
        {
            tickets.Add(0, nextToken.Ticket);
        }else
        {
            tickets.Add(0, "----");
        }
        

        ViewData["tickets"] = tickets;
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
