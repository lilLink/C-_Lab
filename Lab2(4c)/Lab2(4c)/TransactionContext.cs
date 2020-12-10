using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4c_
{
    class TransactionContext : DbContext
    {

        public TransactionContext() : base("DbConnection") { }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
