using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.DataAccessLayer.Models
{
    //contains data related to the items. 
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string ItemName { get; set; }

        public string Description { get; set; } //a short decription about the item

        public string MealCategory { get; set; } //lunch, dinner, breakfast
      
        [Required]
        public double ItemPrice { get; set; } //price of the item

        public string ImageUrl { get;set; } //image location
    }
}
