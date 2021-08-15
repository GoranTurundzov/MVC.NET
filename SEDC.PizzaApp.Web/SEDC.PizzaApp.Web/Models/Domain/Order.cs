using SEDC.PizzaApp.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public User User { get; set; }

        public double Price { get; set; }

        public Pizza Pizza { get; set; }

        public PaymentMethod PaymentMethond { get; set; }

        public bool Delivered { get; set; }
    }
}
