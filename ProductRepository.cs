using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using InventoryManagement.Models;

namespace InventoryManagement.Data
{
    public class ProductRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(
                "SELECT Id, Name, Category, Quantity, Price FROM dbo.Products ORDER BY Id", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        products.Add(ReadProduct(reader));
                }
            }

            return products;
        }

        public Product GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(
                "SELECT Id, Name, Category, Quantity, Price FROM dbo.Products WHERE Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                connection.Open();

                using (var reader = command.ExecuteReader())
                    return reader.Read() ? ReadProduct(reader) : null;
            }
        }

        public void Add(Product product)
        {
            Execute(
                "INSERT INTO dbo.Products (Name, Category, Quantity, Price) VALUES (@Name, @Category, @Quantity, @Price)",
                product);
        }

        public bool Update(Product product)
        {
            return Execute(
                "UPDATE dbo.Products SET Name=@Name, Category=@Category, Quantity=@Quantity, Price=@Price WHERE Id=@Id",
                product) > 0;
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("DELETE FROM dbo.Products WHERE Id=@Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        private int Execute(string sql, Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 80).Value = product.Name;
                command.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = product.Category;
                command.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;

                var price = command.Parameters.Add("@Price", SqlDbType.Decimal);
                price.Precision = 18;
                price.Scale = 2;
                price.Value = product.Price;

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        private static Product ReadProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Category = reader.GetString(2),
                Quantity = reader.GetInt32(3),
                Price = reader.GetDecimal(4)
            };
        }
    }
}
