using System;
using Microsoft.EntityFrameworkCore;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.DataAccessLayer
{
    //This class will handle the interaction between the model classes and the database
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; } 
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderedThrough> OrderedThroughs { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PortionSize> PortionSizes { get; set; }
        public DbSet<Status> Status { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //seeding item data to the item table
            modelBuilder.Entity<Item>()
                .HasData(
                 new Item
                 {
                     Id = 1,
                     ItemCode = "D001",
                     ItemName = "Peking Roasted Duck",
                     Description = "Peking duck is savored for its thin and crispy skin. Sliced Peking duck is often eaten with pancakes, sweet bean sauce, " +
                     "or soy sauce with mashed garlic. It is a must-taste dish in Beijing!",
                     MealCategory = "Dinner",
                     ItemPrice = 790.00,
                     ImageUrl = "/assets/D001.jpeg"
                 },
                 new Item
                 {
                     Id = 2,
                     ItemCode = "D002",
                     ItemName = "Kung Pao Chicken",
                     Description = "Sichuan-style specialty, popular with both Chinese and foreigners. " +
                     "The major ingredients are diced chicken, dried chili, cucumber, and fried peanuts (or cashews)",
                     MealCategory = "Dinner",
                     ItemPrice = 650.00,
                     ImageUrl = "/assets/D002.jpeg"
                 },
                 new Item
                 {
                     Id = 3,
                     ItemCode = "L001",
                     ItemName = "Sweet and Sour Pork",
                     Description = "Sweet and sour pork has a bright orange-red color, and a delicious sweet and sour taste.",                   
                     MealCategory = "Lunch",
                     ItemPrice = 770.00,
                     ImageUrl = "/assets/L001.jpeg"
                 },
                 new Item
                 {
                     Id = 4,
                     ItemCode = "B001",
                     ItemName = "Dim Sum",
                     Description = "Dim sum is one of the most popular Cantonese cuisine dishes. " +
                     "It contains a large range of small dishes, including dumplings, rolls, cakes, and meat, seafood, dessert, and vegetable preparations. ",
                     MealCategory = "Breakfast",
                     ItemPrice = 550.00,
                     ImageUrl = "/assets/B001.jpeg"
                 }

                );
        }
    }
}
