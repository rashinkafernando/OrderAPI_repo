using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.BusinessLayer.Services;
using OrderAPI.DataAccessLayer.Models;

namespace OrderAPI.Controllers
{
    //This controller class has the action methods related to listing food items and searching specific items.

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        //Get all food items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAllItems()
        {
            var items = _itemService.GetAllItems();

            //If there's no item in the db
            if (items == null)
            {
                return NotFound();
            }

            return Ok(items); //returns all the items
        }

        //Get an item by name
        [HttpGet("{ItemName}")]
        public async Task<ActionResult<Item>> GetItemByName(string ItemName)
        {
            var foodItem = await _itemService.GetItemByName(ItemName); //get the item

            //Checking the retrieved result is null
            if (foodItem == null)
            {
                return NotFound();
            }

            return foodItem;
        }
    }
}
