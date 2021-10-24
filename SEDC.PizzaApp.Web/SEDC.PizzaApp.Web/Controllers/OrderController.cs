using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                if(orderDetails == null)
                {
                    return View("_ResourceNotFound");
                }
                var mappedModel = OrderMapper.OrderToOrderDetailsViewModel(orderDetails);
                ViewData.Add("OrderDetails", mappedModel);
                ViewData.Add("Title"  , "Poracki");
                return View(mappedModel);
            }
            
            return View("Error");
        }
        public IActionResult DeleteOrder(int id)
        {
            var order = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return View("ResourceNotFound");
            }
            var mappedOrder = OrderMapper.OrderToOrderDetailsViewModel(order);
            return View(mappedOrder);
        }
            
        public IActionResult DeleteOrderPost(int? id)
        {
            var order = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return View("Resource Not Found");
            }

            StaticDB.Orders.Remove(order);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditOrder(int? id)
        {
            if(id != null)
            {
                var orderDetails = StaticDB.Orders.FirstOrDefault(x => x.Id == id);
                if(orderDetails == null)
                {
                    return View("ResourceNotFount");
                }

                var mappedOrder = OrderMapper.OrderToOrderViewModel(orderDetails);
                ViewBag.Users = StaticDB.Users.Select(user => UserMapper.UserToUserViewModel(user));
                var usersForDropdown = StaticDB.Users.Select(user => UserMapper.UserToUserViewModel(user)).ToList();
                ViewBag.Users1 = new SelectList(usersForDropdown, "Id", "FullName");
                List<UserViewModel> mappedUsers = new List<UserViewModel>();
                foreach(var item in StaticDB.Users)
                {
                    mappedUsers.Add(UserMapper.UserToUserViewModel(item));
                }
                return View(mappedOrder);
            }
           
            return View("ResouceNotFound");
        }
       //DA SE RESI!
       [HttpPost]
        public IActionResult EditOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                Order theOrder = StaticDB.Orders.FirstOrDefault(x => x.Id == order.Id);
                theOrder.PizzaStore = order.PizzaStore;
                theOrder.Pizza.Name = order.PizzaName;
                theOrder.PaymentMethond = order.PaymetMethod;
                theOrder.Delivered = order.Delivered;
                theOrder.User.Address = order.Address;

                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}
