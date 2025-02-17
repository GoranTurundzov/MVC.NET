﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using SEDC.PizzaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class HomeController : Controller
    {


        private IPizzaOrderService _pizzaOrderService;

        public HomeController(IPizzaOrderService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            return RedirectToAction("Order", "Order", new { pizzas = model.NumberOfPizzas });
        }

        public IActionResult Menu()
        {
            List<Pizza> menu = _pizzaOrderService.GetMenu();

            List<PizzaViewModel> pizzas = new List<PizzaViewModel>();

            foreach(Pizza pizza in menu)
            {
                pizzas.Add(new PizzaViewModel
                {
                    Name = pizza.Name,
                    PizzaSize = pizza.PizzaSize,
                    Image = pizza.Image,
                    Id = pizza.Id,
                    Price = pizza.Price
                }
                );
            }

            MenuViewModel model = new MenuViewModel
            {
                Pizzas = pizzas
            };
           

         
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "This is the about page for our pizza app";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "You can find us here!";

            return View();
        }


    }
}
