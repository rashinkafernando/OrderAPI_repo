using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.DataAccessLayer.Interfaces;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.BusinessLayer.Services
{
    public class ItemService
    {
        //Business logic is defined in this service class.

        private readonly IRepositoryItem _item;

        public ItemService(IRepositoryItem item)
        {
            //Built-in dependency injector will inject the dependencies as necessary.
            _item = item;
        }

        //Get all food items
        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                return _item.GetAllItems().ToList(); //returns the list of items
            }
            catch (Exception)
            {
                throw;
            }
        }

        //search a specific food item from the db
        public async Task<Item> GetItemByName(string name)
        {
            try
            {
                return await _item.GetItem(name); //return the specified food item
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
