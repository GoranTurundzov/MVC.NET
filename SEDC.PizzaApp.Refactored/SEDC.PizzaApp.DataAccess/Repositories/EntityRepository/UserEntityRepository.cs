using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.EntityRepository
{
    public class UserEntityRepository : IRepository<User>
    {

        private PizzaDbContext _db;

        public UserEntityRepository(PizzaDbContext db)
        {
            _db = db;
        }
        public void DeleteById(int id)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }

        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.SingleOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _db.Users.Add(entity);
            int id = _db.SaveChanges();
            return id;
        }

        public void Update(User entity)
        {
            User user = _db.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                entity.Id = user.Id;
                _db.Users.Update(entity);
            }
        }
    }
}
