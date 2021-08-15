using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel()
            {

                Id = order.Id,
                PaymentMethod = order.PaymentMethond,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                Price = order.Pizza.HasExtras ? order.Pizza.Price + 10 : order.Pizza.Price,
                Delivered = order.Delivered,
                Address = order.User.Address
            };
        }
    }
}
