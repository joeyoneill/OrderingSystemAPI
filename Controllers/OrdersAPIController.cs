using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using api_obj_3.Models;

namespace api_obj_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersAPIController : ControllerBase
    {
        // Temp Item Initializations
        private static Item water = new Item {
            Id = 1,
            ItemName = "Water",
            ItemPrice = 1.99M
        };
        private static Item milk = new Item {
            Id = 2,
            ItemName = "Milk",
            ItemPrice = 2.99M
        };
        private static Item cheese = new Item {
            Id = 3,
            ItemName = "Cheese",
            ItemPrice = .99M
        };

        // Temp Items List
        List<Item> items = new List<Item> {
            water,
            milk,
            cheese
        };

        // Generic HTTP GET
        [HttpGet]
        public IActionResult Get() {
            return Ok();
        }

        //////////////////////////////////////////////////////////////////////
        // GET: Item API Calls
        //////////////////////////////////////////////////////////////////////
        
        // GET: Returns List of All Items
        [HttpGet("GetItems")]
        public ActionResult<List<Item>> GetItems() {
            return Ok(items);
        }

        // GET: Returns Single Requested Item
        [HttpGet("GetItem/{id}")]
        public ActionResult<Item> GetItem(int id) {
            return Ok(items.FirstOrDefault(i => i.Id == id));
        }

        //////////////////////////////////////////////////////////////////////
        // GET: Order API Calls
        //////////////////////////////////////////////////////////////////////
    }
}