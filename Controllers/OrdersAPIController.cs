using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api_obj_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersAPIController : ControllerBase
    {
        // OrdersAPIController Class Attributes
        private readonly iItemService _itemService;
        private readonly DataContext _context;

        // OrdersAPIController Class Constructor
        public OrdersAPIController(iItemService itemService, DataContext context)
        {
            _itemService = itemService;
            _context = context;
        }

        //////////////////////////////////////////////////////////////////////

        // Generic HTTP GET
        [HttpGet]
        public ActionResult<string> Get() {
            return Ok("Welcome to the Orders API!");
        }

        //////////////////////////////////////////////////////////////////////
        // GET: Item API Calls
        //////////////////////////////////////////////////////////////////////
        
        // GET: Returns List of All Items
        [HttpGet("GetItems")]
        public async Task<ActionResult<List<Item>>> GetItems() {
            // Check if items has items
            if ( _context.Items == null) {
                return NotFound();
            }

            // get items
            var items = await _context.Items.ToListAsync();
            
            // return items list
            return Ok(items);
        }

        // GET: Returns Single Requested Item
        [HttpGet("GetItem/{id}")]
        public async Task<ActionResult<Item>> GetItem(int id) {
            // Check if items has items
            if ( _context.Items == null) {
                return NotFound();
            }

            // get item by id
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);

            // Check if item exists
            if (item == null) {
                return NotFound();
            }
            
            // return item
            return Ok(item);
        }

        //////////////////////////////////////////////////////////////////////
        // POST: Item API Calls
        //////////////////////////////////////////////////////////////////////

        // POST: Add Item to Inventory
        [HttpPost("AddItem")]
        public async Task<ActionResult<List<Item>>> AddItem(Item item) {
            
            // null check
            if (item == null || _context.Items == null)
                return NotFound();

            // Add Item
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            // get items
            var items = await _context.Items.ToListAsync();

            // null check
            if (items == null)
                return NotFound();
            
            // return list
            return Ok(items);
        }
    
        //////////////////////////////////////////////////////////////////////
        // GET: Order API Calls
        //////////////////////////////////////////////////////////////////////

        // GET: Returns All Orders
        [HttpGet("GetOrders")]
        public async Task<ActionResult<List<Order>>> GetOrders() {
            // Orders Table Null check
            if ( _context.Orders == null) {
                return NotFound();
            }

            // get items
            var orders = await _context.Orders.ToListAsync();
            
            // return items list
            return Ok(orders);
        }

        // GET: Returns Order
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id) {
            // Orders Table null check
            if ( _context.Orders == null) {
                return NotFound();
            }

            // get order by id
            var order = await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);

            // Check if item exists
            if (order == null) {
                return NotFound();
            }
            
            // return item
            return Ok(order);
        }

        // GET: Returns Order's Items
        [HttpGet("GetOrderItems/{orderId}")]
        public async Task<ActionResult<List<Item>>> GetOrderItems(int orderId) {
            // initial items null check
            if (_context.Orders == null || _context.Items == null || _context.OrdersItems == null)
                return NotFound();
            
            // get order
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

            // check order
            if (order == null)
                return NotFound();

            // Get All Items from OrdersItems and save to list
            var orderItems = await _context.OrdersItems
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Item) // Include the Item related to each OrdersItems entry
                .Select(oi => oi.Item) // Select the Item from each OrdersItems entry
                .ToListAsync();

            // orderItems null check
            if (orderItems.Count == 0)
                return NotFound();

            return Ok(orderItems);
        }

        //////////////////////////////////////////////////////////////////////
        // POST: Order API Calls
        //////////////////////////////////////////////////////////////////////
    }
}