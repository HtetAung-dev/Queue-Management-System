using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using qms.Models;
using qms.DataAccess;
using qms.common.CommonFunctions;
using qms.common;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace qms.Controllers;

public class CounterController:Controller
{

  [HttpPost]
  public IActionResult ChangeToken1()
  {
    int ret = -1;
    
    Token token = new Token();
    TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
    TokenFunctions tokenFunctions = new TokenFunctions();

    Token prevToken = tokenSqlMgr.GetCounterToken(1);

    if(prevToken.Qid > 0)
    {
      ret = tokenSqlMgr.DeleteToken(prevToken.Qid);
    }
    token = tokenSqlMgr.GetFirstToken();

    if(token.Qid > 0)
    {
      ret = tokenSqlMgr.UpdateQueueIndex(token.Qid, 1);

    } 
    token = tokenSqlMgr.GetCounterToken(1);
   
      return RedirectToAction("Counter1");
  }

  public IActionResult Counter1()
    {
        Token? token = null;
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        token = tokenSqlMgr.GetCounterToken(1);
        
        if(token.Qid == 0)
        {
          token.Ticket = "----";
          token.QueueIndex = 1;
        }
        return View(token);
    }

    //Counter 2
    [HttpPost]
  public IActionResult ChangeToken2()
  {
    int ret = -1;
    
    Token token = new Token();
    TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
    TokenFunctions tokenFunctions = new TokenFunctions();

    Token prevToken = tokenSqlMgr.GetCounterToken(2);

    if(prevToken.Qid > 0)
    {
      ret = tokenSqlMgr.DeleteToken(prevToken.Qid);
    }
    token = tokenSqlMgr.GetFirstToken();

    if(token.Qid > 0)
    {
      ret = tokenSqlMgr.UpdateQueueIndex(token.Qid, 2);

    } 
    token = tokenSqlMgr.GetCounterToken(2);
   
      return RedirectToAction("Counter2");
  }

  public IActionResult Counter2()
    {
        Token? token = null;
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        token = tokenSqlMgr.GetCounterToken(2);
        
        if(token.Qid == 0)
        {
          token.Ticket = "----";
          token.QueueIndex = 2;
        }
        return View(token);
    }

    //Counter 3
    [HttpPost]
  public IActionResult ChangeToken3()
  {
    int ret = -1;
    
    Token token = new Token();
    TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
    TokenFunctions tokenFunctions = new TokenFunctions();

    Token prevToken = tokenSqlMgr.GetCounterToken(3);

    if(prevToken.Qid > 0)
    {
      ret = tokenSqlMgr.DeleteToken(prevToken.Qid);
    }
    token = tokenSqlMgr.GetFirstToken();

    if(token.Qid > 0)
    {
      ret = tokenSqlMgr.UpdateQueueIndex(token.Qid, 3);

    } 
    token = tokenSqlMgr.GetCounterToken(3);
   
      return RedirectToAction("Counter3");
  }

  public IActionResult Counter3()
    {
        Token? token = null;
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        token = tokenSqlMgr.GetCounterToken(3);
        
        if(token.Qid == 0)
        {
          token.Ticket = "----";
          token.QueueIndex = 3;
        }
        return View(token);
    }

    //Counter 4
    [HttpPost]
  public IActionResult ChangeToken4()
  {
    int ret = -1;
    
    Token token = new Token();
    TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
    TokenFunctions tokenFunctions = new TokenFunctions();

    Token prevToken = tokenSqlMgr.GetCounterToken(4);

    if(prevToken.Qid > 0)
    {
      ret = tokenSqlMgr.DeleteToken(prevToken.Qid);
    }
    token = tokenSqlMgr.GetFirstToken();

    if(token.Qid > 0)
    {
      ret = tokenSqlMgr.UpdateQueueIndex(token.Qid, 4);

    } 
    token = tokenSqlMgr.GetCounterToken(4);
   
      return RedirectToAction("Counter4");
  }

  public IActionResult Counter4()
    {
        Token? token = null;
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        token = tokenSqlMgr.GetCounterToken(4);
        
        if(token.Qid == 0)
        {
          token.Ticket = "----";
          token.QueueIndex = 4;
        }
        return View(token);
    }

    //Counter 5
    [HttpPost]
  public IActionResult ChangeToken5()
  {
    int ret = -1;
    
    Token token = new Token();
    TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
    TokenFunctions tokenFunctions = new TokenFunctions();

    Token prevToken = tokenSqlMgr.GetCounterToken(5);

    if(prevToken.Qid > 0)
    {
      ret = tokenSqlMgr.DeleteToken(prevToken.Qid);
    }
    token = tokenSqlMgr.GetFirstToken();

    if(token.Qid > 0)
    {
      ret = tokenSqlMgr.UpdateQueueIndex(token.Qid, 5);

    } 
    token = tokenSqlMgr.GetCounterToken(5);
   
      return RedirectToAction("Counter5");
  }

  public IActionResult Counter5()
    {
        Token? token = null;
        TokenSqlMgr tokenSqlMgr = new TokenSqlMgr();
        token = tokenSqlMgr.GetCounterToken(5);
        
        if(token.Qid == 0)
        {
          token.Ticket = "----";
          token.QueueIndex = 5;
        }
        return View(token);
    }
}