using SEDC.PizzaApp.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class PizzaDetailsViewModel
    {
        public int Id { private get; set; }

        public string Name { get; set; }

        public bool IsOnPromotion { get; set; }

        public double Price { get; set; }

        public PizzaSize Size { get; set; }

        public bool HasExtras { get; set; }

        public int getId()
        {
            return Id;
        }
    }
}
