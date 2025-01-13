using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPLanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace WeddingPLanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Weddings");
        }
        return View("Index");
    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(LogUser returningUser)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == returningUser.LogEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LogEmail", "Invalid login attempt.");
                return View("Index");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(returningUser, userInDb.Password, returningUser.LogPassword);
            if (result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("LogEmail", "Invalid login attempt.");
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Weddings");
        }
        return View("Index");
    }
     [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings()
    {
        User? user = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.LoggedUser = user;
        List<Wedding> AllWeddings = _context.Weddings.Include(w => w.Attendees).ToList();
        return View(AllWeddings);
    }

    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult AddWedding()
    {
        User? user = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.LoggedUser = user;
        return View();
    }

    [SessionCheck]
    [HttpPost("weddings/new")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        User? user = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        if(ModelState.IsValid)
        {
            newWedding.UserID = user.UserId;
            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        ViewBag.LoggedUser = user;
        return View("AddWedding");
    }

    [SessionCheck]
    [HttpPost("weddings/{WeddingId}/delete")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? wedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);
        _context.Weddings.Remove(wedding);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    
    [SessionCheck]
    [HttpGet("weddings/{WeddingId}/rsvp")]
    public IActionResult RSVP(int weddingId)
    {
        User? user = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        RSVP newRSVP = new RSVP
        {
            WeddingId = weddingId,
            UserId = user.UserId
        };
        _context.RSVPs.Add(newRSVP);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    
    [SessionCheck]
    [HttpGet("weddings/{WeddingId}/un-rsvp")]
    public IActionResult UnRSVP(int weddingId)
    {
        User? user = _context.Users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        RSVP? rsvp = _context.RSVPs.SingleOrDefault(r => r.WeddingId == weddingId && r.UserId == user.UserId);
        _context.RSVPs.Remove(rsvp);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpGet("weddings/{WeddingId}")]
    public IActionResult Wedding(int WeddingId)
    {
        User? user = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.LoggedUser = user;
        Wedding? wedding = _context.Weddings
            .Include(w => w.Attendees)
            .ThenInclude(r => r.User)
            .FirstOrDefault(w => w.WeddingId == WeddingId);
        return View(wedding);
    }
    

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

   
}

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Session.GetInt32("UserId") == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}