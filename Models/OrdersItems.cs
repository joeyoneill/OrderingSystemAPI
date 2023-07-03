using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_obj_3.Models
{
    public class OrdersItems
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? ItemId { get; set; }

        //public virtual Item? Item { get; set; }

        //public virtual Order? Order { get; set; }
    }
}