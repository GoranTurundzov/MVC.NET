﻿using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.CacheRepository
{
    public class PizzaRepository : IRepository<Pizza>
    {

   
        public void DeleteById(int id)
        {
            Pizza pizza = CacheDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                CacheDb.Pizzas.Remove(pizza);
            }
        }

        public List<Pizza> GetAll()
        {
            return CacheDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return CacheDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            CacheDb.PizzaId++;
            entity.Id = CacheDb.PizzaId;
            CacheDb.Pizzas.Add(entity);
            return entity.Id;
        }
    

        public void Update(Pizza entity)
        {
        Pizza pizza = CacheDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
        if (pizza != null)
        {
          pizza.Name = entity.Name;
          pizza.Price = entity.Price;
          pizza.IsOnPromotion = entity.IsOnPromotion;
          pizza.PizzaSize = entity.PizzaSize;
        }
        }
    }

}
