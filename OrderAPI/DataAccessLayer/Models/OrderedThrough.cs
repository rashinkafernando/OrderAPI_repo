using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    //How the order is made
    public class OrderedThrough
    {
        [Key]
        public int Id { get; set; }

        public string OrderedMethod { get; set; }
    }
}
