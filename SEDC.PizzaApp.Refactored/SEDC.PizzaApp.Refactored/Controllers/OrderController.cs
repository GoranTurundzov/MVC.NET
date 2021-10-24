using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using SEDC.PizzaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {

        private IPizzaOrderService _pizzaService;
        private IUserService _userService;

        public OrderController(IPizzaOrderService pizzaService, IUserService userService)
        {
            _pizzaService = pizzaService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<Order> Orders = _pizzaService.GetAllOrders();

           

            List<OrderItemViewModel> viewOrders = new List<OrderItemViewModel>();

            foreach(Order order in Orders)
            {
                List<PizzaViewModel> pizzasViewModel = new List<PizzaViewModel>();
                foreach(var pizzaOrder in order.PizzaOrders)
                {
                    pizzasViewModel.Add(new PizzaViewModel
                    {
                        Id = pizzaOrder.Pizza.Id,
                        Image = pizzaOrder.Pizza.Image,
                        Name = pizzaOrder.Pizza.Name,
                        Price = pizzaOrder.Pizza.Price,
                        PizzaSize = pizzaOrder.Pizza.PizzaSize

                    }) ;
                }
                viewOrders.Add(new OrderItemViewModel
                {
                    Id = order.Id,
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Price = order.Price,
                    Pizzas = pizzasViewModel
                });
            }

            OrdersViewModel model = new OrdersViewModel()
            {
                OrdersCount = _pizzaService.GetOrderCount(),
                MostPopularPizza = _pizzaService.GetMostPopularPizza(),
                NameOfFirstCostumer = _userService.GetUsers().Select(x => x.FirstName).FirstOrDefault(),
                LastOrderedPizza = _pizzaService.GetLastOrder().PizzaOrders.FirstOrDefault()?.Pizza?.Name,
                Orders = viewOrders
            };
            return View(model);
        }

        public IActionResult Order(int pizzas)
        {
            OrderViewModel viewModel = new OrderViewModel();

            viewModel.Pizzas = new List<PizzaViewModel>();
            
            for(int i = 0; i < pizzas; i++)
            {
                viewModel.Pizzas.Add(new PizzaViewModel());
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Order(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {

                Order order = new Order();
                List<PizzaOrder> pizzas = new List<PizzaOrder>();

                foreach (PizzaViewModel pizza in model.Pizzas)
                {
                    PizzaOrder pizzaOrder = new PizzaOrder
                    {
                        Pizza = _pizzaService.GetPizzaFromMenu(pizza.Name, pizza.PizzaSize),
                        Order = order,

                    };

                    pizzas.Add(pizzaOrder);

                }

                order.PizzaOrders = pizzas;

                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Phone = model.Phone
                };
                order.User = user;

                _pizzaService.MakeNewOrder(order);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Order");
            }
        }
    }
}
