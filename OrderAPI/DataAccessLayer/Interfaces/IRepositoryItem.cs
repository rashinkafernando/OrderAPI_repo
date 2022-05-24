using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.DataAccessLayer.Interfaces
{
    //contains the abstract methods related to the items
    public interface IRepositoryItem
    {
        public IEnumerable<Item> GetAllItems(); //getting the itemlist
        public Task<Item> GetItem(string name); //search an item using item name

    }
}
