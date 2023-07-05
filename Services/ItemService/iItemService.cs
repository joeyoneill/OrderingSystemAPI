using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_obj_3.Services.ItemService
{
    public interface iItemService
    {
        Task<ServiceResponse<List<Item>>> GetAllItems();
        Task<ServiceResponse<Item>> GetItemById(int id);
        Task<ServiceResponse<List<Item>>> AddItem(Item item);
    }
}