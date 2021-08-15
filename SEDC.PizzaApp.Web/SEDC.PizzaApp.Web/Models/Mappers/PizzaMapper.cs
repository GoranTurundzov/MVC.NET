using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.Mappers
{
    public static class PizzaMapper
    {

        public  static PizzaDetailsViewModel PizzaToPizzaDEtailsViewModel(Pizza pizza)
        {
            PizzaDetailsViewModel pizzaView = new PizzaDetailsViewModel()
            {
                Name = pizza.Name,
                Price = pizza.Price,
                IsOnPromotion = pizza.IsOnPromotion,
                Id = pizza.Id,
                Size = pizza.Size,
                HasExtras = pizza.HasExtras
            };
            return pizzaView;
        }
    }
}
