using Microsoft.AspNetCore.Mvc;

namespace PortfolioI.Controllers;

public class HelloController : Controller

{

[HttpGet]

[Route("")]

public ViewResult Index()

{

return View("Index");

}


[HttpGet("projects")]

public ViewResult Projects()

{

return View("Projects");

}


[HttpGet("contact")]

public ViewResult Contact()

{

return View("Contact");

}

}