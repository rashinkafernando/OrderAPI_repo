using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.BusinessLayer.Services;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.Controllers
{
    //This controller class has the action methods related to making orders and retrieving related details.

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService; //OrderService in BusinessLayer

        public OrderController(OrderService orderService)
        {
            _orderService = orderService; //DI
        }

        //Get all orders
        [HttpGet]
        public ActionResult<OrderList> GetAllOrders()
        {
            var orderList = _orderService.GetAllOrders();

            //If there's no order in the db
            if(orderList == null)
            {
                return NotFound();
            }

            return Ok(orderList); //returns all the orders
        }

        //Get an order by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var orderItem = await _orderService.GetOrderById(id); //get the order

            //Checking the retrieved result is null
            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        //Create an order
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {           
            await _orderService.AddOrder(order);

            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        //update order status
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderStatus([FromRoute] int id, [FromBody] int status)
        {            
            await _orderService.UpdateOrderStatus(id, status);

            return NoContent();
        }
    }
}
