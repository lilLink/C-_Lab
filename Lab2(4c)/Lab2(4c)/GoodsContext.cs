using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4c_
{
    class GoodsContext : DbContext
    {

        public GoodsContext() : base("DbConnection")
        {
        }

        public DbSet<Goods> Goods { get; set; }

    }
}
