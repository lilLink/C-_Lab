using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab1_4c_
{
    class Program
    {
        public static List<object[]> GetResult(NpgsqlConnection connection, string select, string from, string where)
        {
            var sqlStatement = string.Format("SELECT {0} FROM {1} WHERE {2}", select, from, where);

            //var sqlCommand = new NpgsqlCommand(sqlStatement, connection);
            try
            {
                connection.Open();

                List<object[]> result = new List<object[]>();
                using (NpgsqlCommand command = new NpgsqlCommand(sqlStatement, connection))
                {
                    using (NpgsqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var values = new object[dataReader.FieldCount];
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                values[i] = dataReader[i];
                            }
                            result.Add(values);
                        }
                    }
                }
                connection.Close();
                return result;
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }

        public static void printData(List<object[]> list)
        {
            int count = 0;
            foreach (object[] element in list)
            {
                count++;
                StringBuilder sb = new StringBuilder();
                foreach (var v in element)
                {
                    sb.Append(v.ToString());
                    sb.Append("   |   ");
                }
                Console.WriteLine(sb);
            }
            Console.WriteLine($"Number of elements: {count}");
        }

        static void Main(string[] args)
        {
            try
            {
                NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();

                builder.ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=serj5130;Database=trading_operations;";

                using (NpgsqlConnection connection = new NpgsqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nData Base should include information:");
                    Console.WriteLine("=========================================\n\n");
                    Console.WriteLine("\n10 clients:\n");
                    List<object[]> clients = GetResult(connection, "*", "clients", "true");
                    printData(clients);

                    Console.WriteLine("=========================================\n\n");
                    Console.WriteLine("\n5 types of goods:");
                    List<object[]> goods = GetResult(connection, "*", "goods", "true");
                    printData(goods);

                    Console.WriteLine("=========================================\n\n");
                    Console.WriteLine("\nTransactions:");
                    List<object[]> transactions = GetResult(connection, "*", "trade", "true");
                    printData(transactions);


                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}
