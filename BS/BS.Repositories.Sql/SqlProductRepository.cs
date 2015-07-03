using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Entities;

namespace BS.Repositories.Sql
{
    public class SqlProductRepository : IProductRepository
    {
        // queries
        string querySelect = "SELECT [Id],[Name],[Article],[ProducerId],[Description],[ProductGroupId] FROM [dbo].[tblProduct] ORDER BY [Name] DESC";
        string queryCount = "SELECT COUNT(*) FROM [dbo].[tblProduct]";
        string connectionString = "Server=RUSLANA-ПК;DataBase=BS_KRV;User=sa;password=19999";

        public List<Product> SelectAll()
        {
            int counter = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(querySelect, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> product = new List<Product>();
                        while (reader.Read())
                        {
                            counter++;
                            product.Add(new Product()
                            {
                                npp = counter,
                                Id = (int)reader["id"],
                                Name = (string)reader["Name"],
                                Article = (object.Equals(reader["Article"], DBNull.Value) == false
                                                            ? (string)reader["ProducerId"]
                                                            : default(string)),
                                ProducerId = (object.Equals(reader["ProducerId"], DBNull.Value) == false
                                                            ? (int?)reader["ProducerId"]
                                                            : default(int?)),
                                Description = (object.Equals(reader["Description"], DBNull.Value) == false
                                                            ? (string)reader["Description"]
                                                            : default(string)),
                                ProductGroupId = (object.Equals(reader["ProductGroupId"], DBNull.Value) == false
                                                            ? (int?)reader["ProductGroupId"]
                                                            : default(int?))
                            });
                        }
                        return product;
                    }
                }
            }
        }

        public int CountRecords()
        {
            int countRecord = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryCount, connection))
                {
                    countRecord = (int)command.ExecuteScalar();
                }
            }

            return countRecord;
        }
    }
}
