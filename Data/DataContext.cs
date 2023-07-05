using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_obj_3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // tables
        public DbSet<Item>? Items { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrdersItem>? OrdersItems { get; set; }
    }
}