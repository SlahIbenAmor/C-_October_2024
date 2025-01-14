﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext { get; set; }

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> Dishes = dbContext.Dishes
                                .OrderByDescending(d => d.DishesId)
                                .ToList();
            return View(Dishes);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("viewdish/{dishesid}")]
        public IActionResult ViewDish(int dishesId)
        {
            Dish retrievedDish = dbContext.Dishes
                                .FirstOrDefault(d => d.DishesId.Equals(dishesId));
            ViewBag.Dishes = retrievedDish;

            return View();
        }

        [HttpGet("editdish/{dishesid}")]
        public IActionResult EditDish(Dish dish)
        {

            Dish retrievedDish = dbContext.Dishes
                                .FirstOrDefault(d => d.DishesId == dish.DishesId);


            return View(retrievedDish);
        }


        [HttpPost("editupdate")]
        public IActionResult EditUpdate(Dish dish)
        {
            if (ModelState.IsValid)
            {
                Dish retrievedDish = dbContext.Dishes
                                    .FirstOrDefault(d => d.DishesId == dish.DishesId);
                retrievedDish.ChefName = dish.ChefName;
                retrievedDish.DishName = dish.DishName;
                retrievedDish.Calories = dish.Calories;
                retrievedDish.Tastiness = dish.Tastiness;
                retrievedDish.Description = dish.Description;
                retrievedDish.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("EditDish", dish);
            }
        }

        [HttpGet("deletedish/{dishesid}")]
        public IActionResult DeleteDish(int dishesId)
        {
            Dish retrievedDish = dbContext.Dishes
                                .FirstOrDefault(d => d.DishesId.Equals(dishesId));
            dbContext.Dishes.Remove(retrievedDish);
            dbContext.SaveChanges();
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
}