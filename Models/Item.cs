using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_obj_3.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string ItemName { get; set; } = null!;

        public decimal ItemPrice { get; set; }

        //public virtual ICollection<OrdersItem> OrdersItems { get; set; } = new List<OrdersItem>();
    }
}