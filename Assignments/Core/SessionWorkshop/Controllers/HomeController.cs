using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

       
    [HttpPost]
    public IActionResult Register(Player model)
    {
         if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("UserName", model.Name);
            return RedirectToAction ("Dashboard");
        }
       return View ("Index");
    }


    [HttpPost ("logout")]
    public IActionResult Logout ()
    {
            HttpContext.Session.Clear();
            return View ("Index");
    }

    
    [HttpGet("dashboard")]
    public IActionResult Dashboard (int CurrentValue)
    {
        string? UserName = HttpContext.Session.GetString("UserName");
        if (UserName == null)
        {
            return RedirectToAction ("Index");
        }
       
        return View ();
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
