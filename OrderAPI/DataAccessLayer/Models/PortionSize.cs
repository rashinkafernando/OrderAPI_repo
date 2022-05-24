using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    //The size of the portions
    public class PortionSize
    {
        [Key]
        public int Id { get; set; }

        public string Size { get; set; } //Small, medium, large
    }
}
