using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For Session
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("products");
    }
    ///////////////PRODUCTS PAGE///////////////////
    [HttpGet("products")]
    public IActionResult Products()
    {
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }
    ///////////////ONE PRODUCT PAGE///////////////////
    [HttpGet("product/{ProductId}")]
    public IActionResult OneProduct(int ProductId)
    {
        ViewBag.Product = _context.Products.FirstOrDefault(a => a.ProductId == ProductId);

        ViewBag.ProductCategories = _context.Categories.Include(i => i.RelatedItems).ThenInclude(c => c.Product).Where(j => j.RelatedItems.Any(p => p.ProductId == ProductId)).ToList();

        ViewBag.AllCategories = _context.Categories.Include(i => i.RelatedItems).ThenInclude(c => c.Product).Where(j => !(j.RelatedItems.Any(p => p.ProductId == ProductId))).ToList(); ;
        return View();
    }
    ///////////////ADD CATEGORY TO PRODUCT///////////////////
    [HttpPost("association/add")]
    public IActionResult AddAssociation(Association newAssociation)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return Redirect($"/product/{newAssociation.ProductId}");
        }
        return View("OneProduct");
    }
    ///////////////CATEGORY PAGE///////////////////
    [HttpGet("categories")]
    public IActionResult Categories()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }
    ///////////////ONE CATEGORY PAGE///////////////////
    [HttpGet("category/{CategoryId}")]
    public IActionResult OneCategory(int CategoryId)
    {
        ViewBag.Category = _context.Categories.FirstOrDefault(a => a.CategoryId == CategoryId);

        ViewBag.CategoryProducts = _context.Products.Include(i => i.Associations).ThenInclude(c => c.Category).Where(j => j.Associations.Any(p => p.CategoryId == CategoryId)).ToList();

        ViewBag.AllProducts = _context.Products.Include(i => i.Associations).ThenInclude(c => c.Category).Where(j => !(j.Associations.Any(p => p.CategoryId == CategoryId))).ToList();
        return View();
    }
    ///////////////ADD CATEGORY TO PRODUCT///////////////////
    [HttpPost("relatedItem/add")]
    public IActionResult AddRelatedItem(Association newRelatedItem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newRelatedItem);
            _context.SaveChanges();
            return Redirect($"/category/{newRelatedItem.CategoryId}");
        }
        return View("OneCategory");
    }
    ///////////////ADD PRODUCT///////////////////
    [HttpPost("add/product")]
    public IActionResult AddProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("products");
        }
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }
    ///////////////ADD CATEGORY///////////////////
    [HttpPost("add/category")]
    public IActionResult AddCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("categories");
        }
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("Categories");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
