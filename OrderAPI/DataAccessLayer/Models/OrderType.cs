using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    //List the type of order
    public class OrderType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; } //Dine in or Take away
    }
    
}
