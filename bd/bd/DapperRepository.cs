using Dapper;
using Npgsql;
using bd.Models;

namespace bd
{
    class DapperRepository
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            using var conn = new NpgsqlConnection(Config.SqlConnectionString);
            string sql = @"select * from customers";
            return conn.Query<Customer>(sql);
        }

        public static IEnumerable<Customer> GetCustomers(int age)
        {
            using var conn = new NpgsqlConnection(Config.SqlConnectionString);
            string sql = @"select * from customers where age = @age";
            return conn.Query<Customer>(sql, new { age });
        }

        public static IEnumerable<Order> GetOrders()
        {
            using var conn = new NpgsqlConnection(Config.SqlConnectionString);
            string sql = @"select * from orders";
            return conn.Query<Order>(sql);
        }

        public static IEnumerable<Order> GetOrders(int quantity)
        {
            using var conn = new NpgsqlConnection(Config.SqlConnectionString);
            string sql = @"select * from orders where quantity = @quantity";
            return conn.Query<Order>(sql, new { quantity });
        }

        public static IEnumerable<Product> GetProducts()
        {
            using var conn = new NpgsqlConnection(Config.SqlConnectionString);
            string sql = @"select * from products";
            return conn.Query<Product>(sql);
        }

        public static IEnumerable<Product> GetProducts(decimal price)
        {
            using var conn = new NpgsqlConnection(Config.SqlConnectionString);
            string sql = @"select * from products where price = @price";
            return conn.Query<Product>(sql, new { price });
        }
    }
}
