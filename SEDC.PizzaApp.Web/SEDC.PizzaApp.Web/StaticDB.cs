using SEDC.PizzaApp.Web.Models;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web
{
    public class StaticDB
    {
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name = "Margarita",
                IsOnPromotion = true,
                Price = 7,
                Size = PizzaSize.Fammily,
                HasExtras = false
            } ,
             new Pizza()
            {
                Id = 2,
                Name = "Kapri",
                IsOnPromotion = false,
                   Price = 6.5,
                 Size = PizzaSize.Normal,
                  HasExtras = true
            } ,
              new Pizza()
            {
                Id = 3,
                Name = "QuatroFormagi",
                IsOnPromotion = false,
                  Price = 8,
                  Size = PizzaSize.Fammily,
                   HasExtras = false,
                   
            } ,
        };

        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                Address = "Partizanska 55",
                Phone = 0712345678
            },
             new User()
            {
                Id = 2,
                FirstName = "Phill",
                LastName = "Phillsky",
                Address = "Ilindenska 55",
                Phone = 0712534378
            }, new User()
            {
                Id = 3,
                FirstName = "Jill",
                LastName = "Jillsky",
                Address = "Ruzveltova 55",
                Phone = 0712334534
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                PaymentMethond = PaymentMethod.Cash,
                User = Users.First(),
                Pizza = Pizzas.First(),
                Price = Pizzas.First().Price,
                Delivered = false,
                PizzaStore = "Jakomo"
            },
              new Order()
            {
                Id = 2,
                PaymentMethond = PaymentMethod.Cash,
                User = Users.FirstOrDefault(x => x.Id == 2),
                Pizza = Pizzas.FirstOrDefault(x => x.Id == 2),
                Price = Pizzas.FirstOrDefault(x => x.Id == 2).Price,
                 Delivered = false,
                 PizzaStore = "Dominos"
            },
                new Order()
            {
                Id = 3,
                PaymentMethond = PaymentMethod.Card,
                User = Users.Last(),
                Pizza = Pizzas.Last(),
                Price = Pizzas.Last().Price,
                 Delivered = true,
                 PizzaStore = " Mama Mia"
            },
        };
    }
}