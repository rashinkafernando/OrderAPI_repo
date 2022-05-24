using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.DataAccessLayer.Interfaces
{
    //contains the abstract methods related to the order
    public interface IRepositoryOrder
    {
        public Task<Order> CreateOrder(Order order);
        public IEnumerable<Order> GetAllQueueOrders(); //getting the orderlist 

        public Task<Order> GetOrder(int id); //get an order using order reference id

        public IEnumerable<Order> GetAllPreparedOrders(); //getting the orderlist - preparing

        public Task<int> UpdateOrderStatus(int id, int status); //change status from in queue to prepared

    }
}
