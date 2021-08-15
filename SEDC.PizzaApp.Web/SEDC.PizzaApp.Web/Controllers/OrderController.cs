using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Mappers;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult Index()
        {
            //var PizzaMargarita = StaticDB.Pizzas.First();
            //User newUser = new User()
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Phone = 070777555,
            //    Address = "Ruzveltova 3"
            //};

            //Order order = new Order()
            //{
            //    Pizza = PizzaMargarita,
            //    User = newUser,
            //    PaymentMethond = Models.Enums.PaymentMethod.Cash,
            //    Price = PizzaMargarita.Price
            //};

            //OrderDetailsViewModel theOrder = new OrderDetailsViewModel()
            //{
            //    Id = order.Id,
            //    PaymentMethod = order.PaymentMethond,
            //    PizzaName = PizzaMargarita.Name,
            //    UserFullName = $"{order.User.FirstName} {order.User.LastName}",
            //    Price = PizzaMargarita.Price
            //};
            ViewData.Add("Title", "Poracki");
            List<Order> orders = StaticDB.Orders;
            List<OrderDetailsViewModel> orderDetails = new List<OrderDetailsViewModel>();
            foreach(Order order in orders)
            {
                orderDetails.Add(OrderMapper.OrderToOrderDetailsViewModel(order));
            }
            return View(orderDetails);
        }
        public IActionResult OrderDetails(int id)
        {
            if(id > 0)
            {
                var orderDetails = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
                var mappedModel = OrderMapper.OrderToOrderDetailsViewModel(orderDetails);
                ViewData.Add("OrderDetails", mappedModel);
                ViewData.Add("Title"  , "Poracki");
                return View(mappedModel);
            }
            
            return View("Error");
        }
    }
}
