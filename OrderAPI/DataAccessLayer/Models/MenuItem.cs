using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    //This class contains data about the menu. This class will be used when placing the order.

    public class MenuItem
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public string ItemCode { get; set; }        
                  
        public string Description { get; set; } //a short decription about the item, such as name

        [Required]
        public int PortionSize { get; set; } //sizes will be small,medium,large

        [Required]
        public int NoOfItems { get; set; }

        [Required]
        public double Price { get; set; } //total amount per menu item
        
    }
}
