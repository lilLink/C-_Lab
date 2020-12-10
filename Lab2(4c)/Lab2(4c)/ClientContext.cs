using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4c_
{
    class ClientContext : DbContext
    {

        public ClientContext() : base("DbConnection"){
        }

        public DbSet<Client> Clients { get; set; }

    }
}
