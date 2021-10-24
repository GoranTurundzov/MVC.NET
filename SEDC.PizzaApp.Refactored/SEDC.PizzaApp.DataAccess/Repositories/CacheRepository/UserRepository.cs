using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.CacheRepository
{
    public class UserRepository : IRepository<User>
    {

        public void DeleteById(int id)
        {
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                CacheDb.Users.Remove(user);
            }
        }

        public List<User> GetAll()
        {
            return CacheDb.Users;
        }

       // public List<User> GetAll() => CacheDb.Users;
        

        public User GetById(int id)
        {
            return CacheDb.Users.FirstOrDefault(x => x.Id == id);
          
        }

        public int Insert(User entity)
        {
            CacheDb.UsersId++;
            entity.Id = CacheDb.UsersId;
            CacheDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            //if(user != null)
            //{
            //    int indexOfUser = CacheDb.Users.IndexOf(user);
            //    CacheDb.Users[indexOfUser] = entity;
            //}
            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Address = entity.Address;
                user.Phone = entity.Phone;
            }




        }

  
    }
}
