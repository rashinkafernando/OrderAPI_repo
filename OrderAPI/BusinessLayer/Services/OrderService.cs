using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.DataAccessLayer.Interfaces;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.BusinessLayer.Services
{
    //Business logic is defined in this service class.
    public class OrderService
    {
        private readonly IRepositoryOrder _order;

        public OrderService(IRepositoryOrder order)
        {
            //Built-in dependency injector will inject the dependencies as necessary.
            _order = order;
        }

        //Create an order
        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                return await _order.CreateOrder(order);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get all orders - both in queue and preparing
        public OrderList GetAllOrders()
        {
            try
            {
                OrderList orderList = new OrderList(); //create a new order list object
                orderList.QueueList = _order.GetAllQueueOrders().ToList();
                orderList.PreparingList = _order.GetAllPreparedOrders().ToList();
                return orderList;
                                                             
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Get an order
        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                return await _order.GetOrder(id); //return the specified order
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Update order status
        public async Task<int> UpdateOrderStatus(int id, int status)
        {
            try
            {
                return await _order.UpdateOrderStatus(id, status);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
