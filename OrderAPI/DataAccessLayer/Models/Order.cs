using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    //This class will contain data related to the Order
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }        

        [Required]
        public int OrderedThrough { get; set; } //The way the order is made - online or POS

        [Required]
        public int OrderType { get; set; } //Dine in or Take away

        [Required]
        public int OrderStatus { get; set; }

        public List<MenuItem> MenuItems { get; set; }

    }

    public class OrderList
    {
        public List<Order> QueueList { get; set; } //queue order list
        public List<Order> PreparingList { get; set; } //preparing order list
    }
}
