using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Services.Interface
{
    public interface IUserService
    {
        List<User> GetUsers();

        int AddNewUser(User entity);

        string GetLastUserName();

    }
}
