using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.Services.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private IRepository<Pizza> _pizzaRepository;
        private IRepository<Order> _orderRepository;
        public PizzaOrderService(IRepository<Pizza> repository , IRepository<Order> orderRepository)
        {
            _pizzaRepository = repository;
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetLastOrder()
        {
            return _orderRepository.GetAll().LastOrDefault();
        }

        public List<Pizza> GetMenu()
        {
            return _pizzaRepository.GetAll();
        }

        public string GetMostPopularPizza()
        {
            List<Order> Orders = _orderRepository.GetAll();

            List<PizzaOrder> pizzas = Orders.SelectMany(x => x.PizzaOrders).ToList();

            string mostPopularPizza = pizzas.GroupBy(x => x.Pizza.Name)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault()
                .Select(x => x.Pizza.Name)
                .FirstOrDefault();


            return mostPopularPizza;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public int GetOrderCount()
        {
            return _orderRepository.GetAll().Count;
        }

        public void MakeNewOrder(Order order)
        {
            _orderRepository.Insert(order);
        }

        public Pizza GetPizzaFromMenu(string pizzaName, PizzaSize pizzaSize)
        {
           // List<Pizza> pizzas = _pizzaRepository.GetAll();
            return _pizzaRepository.GetAll().FirstOrDefault(x => x.Name == pizzaName && x.PizzaSize == pizzaSize);
        }
    }
}
