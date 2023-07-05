using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_obj_3.Models
{
    public class Order
    {
         public int Id { get; set; }

        public string OrderName { get; set; } = null!;

        public string OrderAddress { get; set; } = null!;

        public decimal? Subtotal { get; set; }

        //public virtual ICollection<OrdersItem> OrdersItems { get; set; } = new List<OrdersItem>();
    }
}