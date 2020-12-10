using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4c_
{
    class Transaction
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
        public int Discount { get; set; }
        public int ClientId { get; set; }
        public int GoodsId { get; set; }

    }
}
