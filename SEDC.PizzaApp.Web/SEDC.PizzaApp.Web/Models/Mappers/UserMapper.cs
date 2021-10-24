using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Models.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel UserToUserViewModel(User user)
        {
            return new UserViewModel() {
                FullName = user.FirstName + " " + user.LastName,
                Id = user.Id
            };

        }
    }
}
