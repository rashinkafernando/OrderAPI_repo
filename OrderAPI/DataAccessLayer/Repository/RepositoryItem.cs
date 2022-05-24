using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.DataAccessLayer.Interfaces;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.DataAccessLayer.Repository
{
    //Implementation of IRepositoryItem interface    
    public class RepositoryItem : IRepositoryItem
    {
        ApplicationDbContext _context; //Declare a DbContext variable

        public RepositoryItem(ApplicationDbContext context)
        {
            _context = context;
        }

        //Retrieve all the food items in the database
        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                return _context.Items.ToList(); //returns the list of items
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Search and retrieve a specific food item
        public async Task<Item> GetItem(string name)
        {
            try
            {
                return await _context.Items.FindAsync(name); //returns the object when the item name given
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
