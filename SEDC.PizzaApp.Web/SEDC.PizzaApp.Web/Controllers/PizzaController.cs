using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models;
using SEDC.PizzaApp.Web.Models.Mappers;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List < Pizza >pizzas = StaticDB.Pizzas;
            List<PizzaDetailsViewModel> pizzaList = new List<PizzaDetailsViewModel>();
            foreach(Pizza pizza in pizzas)
            {
                pizzaList.Add(PizzaMapper.PizzaToPizzaDEtailsViewModel(pizza));
            }
            return View(pizzaList);
        }


        public IActionResult PizzaDetail(int id)
        {
            Pizza pizza = StaticDB.Pizzas.FirstOrDefault(x => x.Id == id);
            PizzaDetailsViewModel pizzaView = PizzaMapper.PizzaToPizzaDEtailsViewModel(pizza);
            return View(pizzaView);
        }
    }


}
