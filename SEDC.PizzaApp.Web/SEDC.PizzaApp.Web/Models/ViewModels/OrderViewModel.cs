using SEDC.PizzaApp.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public PaymentMethod PaymetMethod { get; set; }
        [Display(Name = "Name Of Pizza")]
        public string PizzaName { get; set; }

        public string PizzaStore { get; set; }

        public double Price { get; set; }

        public string Address { get; set; }

        public bool Delivered { get; set; }


        public int UserId { get; set; }

        //public string UserFullName { get; set; }
    }
}
