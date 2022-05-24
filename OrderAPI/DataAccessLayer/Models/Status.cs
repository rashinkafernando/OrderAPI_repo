using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        public string OrderStatus { get; set; }
    }
}
