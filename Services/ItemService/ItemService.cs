using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_obj_3.Services.ItemService
{
    public class ItemService : iItemService
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
        List<Item> inventory = new List<Item> {
            water,
            milk,
            cheese
        };

        //////////////////////////////////////////////////////////////////////

        public async Task<ServiceResponse<List<Item>>> AddItem(Item item)
        {
            inventory.Add(item);

            // Return Object
            var serviceResponse = new ServiceResponse<List<Item>>();
            serviceResponse.Data = inventory;

            // Return
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> GetAllItems()
        {
            // Service Response
            var serviceResponse = new ServiceResponse<List<Item>>();
            serviceResponse.Data = inventory;

            // return service response object
            return serviceResponse;
        }

        public async Task<ServiceResponse<Item>> GetItemById(int id)
        {
            // Get Item
            Item? item = inventory.FirstOrDefault(i => i.Id == id);

            // Service Response
            var serviceResponse = new ServiceResponse<Item>();
            serviceResponse.Data = item;

            // return serv resp obj
            return serviceResponse;
        }
    }
}