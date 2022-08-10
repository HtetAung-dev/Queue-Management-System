using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using qms.Models;
using qms.DataAccess;
using qms.common.CommonFunctions;
using qms.common;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace qms.Controllers;

public class TokenController : Controller
{
    TokenFunctions tockenFunctions = new TokenFunctions();
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Token token)
    {
        Token lastToken = new Token();
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        lastToken = tokenSqlMgr.GetLastToken();
        int ret = -1;
        if(lastToken != null)
        {
            token.Ticket = tockenFunctions.GenerateToken(lastToken.Ticket);
        }
        ret = tokenSqlMgr.createToken(token);
        if(ret > 0)
        {
            lastToken = tokenSqlMgr.GetTokenInfo(ret);
            return RedirectToAction(nameof(PrintToken), lastToken);
        }
        else
        {
            return View();
        }
    }

  

    public IActionResult PrintToken(Token token)
    {
        return View(token);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
