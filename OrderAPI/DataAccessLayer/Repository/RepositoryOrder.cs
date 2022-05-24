using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderAPI.DataAccessLayer.Enums;
using OrderAPI.DataAccessLayer.Interfaces;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.DataAccessLayer.Repository
{
    //Implementation of IRepositoryOrder interface    
    public class RepositoryOrder : IRepositoryOrder
    {
        ApplicationDbContext _context; //Declare a DbContext variable

        //built-in dependency injector will inject the mentioned dependency services as required.
        //And will discard them when they are no longer needed.
        public RepositoryOrder(ApplicationDbContext context)
        {
            _context = context; //assigning the dependency service to the declared context variable.
        }

        //This method will be called to create a new order.
        //By mentioning async, the method has become asynchronous
        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                //Since async is mentioned above, await must be added too.
                var obj = await _context.Orders.AddAsync(order);
                _context.SaveChanges(); //Save the order in the database.
                return obj.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /**
          * This method is used retrieve all the orders from the database. Only orders in queue.
         */
        public IEnumerable<Order> GetAllQueueOrders()
        {
            try
            {
                int statusVal = (int)OrderStatusEnum.InQueue; //get the enum value of in queue             

                var list = _context.Orders.Where(x => x.OrderStatus == statusVal)
                              .Include(s => s.MenuItems).ToList(); 
                return list; //return order list

            }
            catch (Exception)
            {
                throw;
            }
        }       

        //This method is used to retrieve an order using id
        public async Task<Order> GetOrder(int id)
        {
            try
            {
                return await _context.Orders.FindAsync(id); //returns the object when the id given
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get preparing orders
        public IEnumerable<Order> GetAllPreparedOrders()
        {
            try
            {
                int statusVal = (int)OrderStatusEnum.OrderReady; //get the enum value

                var list = _context.Orders.Where(x => x.OrderStatus == statusVal)
                              .Include(s => s.MenuItems).ToList();
                return list; //return order list
            }
            catch (Exception)
            {
                throw;
            }
        }

        //method to update the order status
        public async Task<int> UpdateOrderStatus(int id, int status)
        {
            try
            {
                var obj = await _context.Orders.FindAsync(id);
                obj.OrderStatus = status; //change order status
                _context.Update(obj); //update the value
                _context.SaveChanges(); //save the changes in the db

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
