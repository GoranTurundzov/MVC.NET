using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class UserController : Controller
    {

        #region ReadOperations
        public IActionResult Index()
        {
            List<User> users = StaticDB.Users;
                
            return View(users);
        }


        public IActionResult Details(int id)
        {
            User user = StaticDB.Users.SingleOrDefault(x => x.Id == id);
            if(user != null)
            {
                return View(user);
            }
            return View("ResourceNotFound");
        }
        #endregion

        #region Create
            [HttpGet]  //default is HttpGet
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                StaticDB.Users.Add(user);
                return RedirectToAction("Index");
            } else
            {
                return View("Error");
            }
            
        }

        #endregion

        #region Update
        public IActionResult Edit(int id)
        {
            User user = StaticDB.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                return View(user);
            }
            return View("ResourceNotFound");
        }
        [HttpPost]
        public IActionResult Edit(User userModel)
        {
            if (ModelState.IsValid)
            {
                User dbUser = StaticDB.Users.SingleOrDefault(x => x.Id == userModel.Id);
                dbUser.FirstName = userModel.FirstName;
                dbUser.LastName = userModel.LastName;
                dbUser.Phone = userModel.Phone;
                dbUser.Address = userModel.Address;
                
                //dbUser = userModel;
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            User user = StaticDB.Users.SingleOrDefault(x => x.Id == id);
            return View();
        }

        public IActionResult Delete(int? id)
        {
            return View();
        }

        #endregion
    }
}
