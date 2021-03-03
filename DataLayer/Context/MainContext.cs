using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MainContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<GoodsGroup> GoodsGroups { get; set; }
        public DbSet<Good> Goods { get; set; }
    }
}
