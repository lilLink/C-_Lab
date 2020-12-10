using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_4c_
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ClientContext db = new ClientContext())
            {
                Console.WriteLine("\nData Base should include information:");
                Console.WriteLine("=========================================\n\n");
                Console.WriteLine("\n10 clients:\n");
                Console.WriteLine("{0}.{1} - {2} - {3} - {4}", "Id", "Name", "Director", "PhoneNumber", "RegisteredOffice");

                var clients = db.Clients;
                foreach(Client client in clients)
                {
                    Console.WriteLine("{0}.{1} - {2} - {3} - {4}", client.Id, client.Name, client.Director, client.PhoneNumber, client.RegisteredOffice);
                }
            }

            using(GoodsContext db = new GoodsContext())
            {
                Console.WriteLine("=========================================\n\n");
                Console.WriteLine("\n5 types of goods:");
                Console.WriteLine("{0}.{1} - {2} - {3} - {4}", "Id", "Name", "Price", "UnitOfMeasure", "Description");

                var goods = db.Goods;
                foreach(Goods g in goods)
                {
                    Console.WriteLine("{0}.{1} - {2} - {3} - {4}", g.Id, g.Name, g.Price, g.UnitOfMeasure, g.Description);
                }
            }

            using(TransactionContext db = new TransactionContext())
            {
                Console.WriteLine("=========================================\n\n");
                Console.WriteLine("\nTransactions:");
                Console.WriteLine("{0}.{1} - {2} - {3} - {4}", "Id", "Quantity", "Date", "Discount", "ClientId", "GoodsId");

                var transactions = db.Transactions;
                foreach(Transaction transaction in transactions)
                {
                    Console.WriteLine("{0}.{1} - {2} - {3} - {4}", transaction.Id, transaction.Quantity, transaction.Date, transaction.Discount, transaction.ClientId, transaction.GoodsId);
                }
            }
        }
    }
}
