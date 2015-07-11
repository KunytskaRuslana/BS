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
        string querySelect = "SELECT [Id],[Name],[Article],[ProducerId],[Description],[ProductGroupId]" 
                           + "FROM [dbo].[tblProduct] ORDER BY [Name] DESC";
        string queryGetAllId = "SELECT [Id],[Name],[Article],[Description]"
                             + "FROM [dbo].[tblProduct]"
                             + "WHERE [Id] = @Id";
        string queryCount = "SELECT COUNT(*) FROM [dbo].[tblProduct]";
        string queryInsert = "INSERT INTO [dbo].[tblProduct] ([Name],[Article],[Description]) VALUES (@Name,@Article,@Description); SELECT CAST(SCOPE_IDENTITY() AS INT);";
        string queryUpdate = "UPDATE [dbo].[tblProduct] SET [Name] = @Name, [Article] = @Article, [Description] = @Description WHERE [Id] = @Id";
        string queryDelete = "DELETE FROM [dbo].[tblProduct] WHERE [Id] = @Id";
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
                                                            ? (string)reader["Article"]
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

        public Product AddRecord(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    //command.Parameters.AddWithValue("Id", myListProduct.Id);
                    command.Parameters.AddWithValue("Name", product.Name);
                    command.Parameters.AddWithValue("Article", product.Article);
                    command.Parameters.AddWithValue("Description", product.Description);

                    int connectId = (int)command.ExecuteScalar();
                    product.Id = connectId;

                    return product;
                }
            }
        }

        public void EditRecord(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryUpdate, connection))
                {
                    command.Parameters.AddWithValue("Id", product.Id);
                    command.Parameters.AddWithValue("Name", product.Name);
                    command.Parameters.AddWithValue("Article", product.Article);
                    command.Parameters.AddWithValue("Description", product.Description);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRecord(int prodId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    command.Parameters.AddWithValue("Id", prodId);

                    command.ExecuteNonQuery();
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

        public int GetId(int numRecord)
        {
            int _id = 0;
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
                                Id = (int)reader["id"],
                                Name = (string)reader["Name"],
                                Article = (object.Equals(reader["Article"], DBNull.Value) == false
                                                            ? (string)reader["Article"]
                                                            : default(string)),
                                ProducerId = (object.Equals(reader["ProducerId"], DBNull.Value) == false
                                                            ? (int?)reader["ProducerId"]
                                                            : default(int?)),
                                Description = (object.Equals(reader["Description"], DBNull.Value) == false
                                                            ? (string)reader["Description"]
                                                            : default(string)),
                                ProductGroupId = (object.Equals(reader["ProductGroupId"], DBNull.Value) == false
                                                            ? (int?)reader["ProductGroupId"]
                                                            : default(int?)),
                                npp = counter
                            });
                        }

                        foreach (var item in product)
                        {
                            if (item.npp == numRecord)
                            {
                                _id = item.Id;
                                break;
                            }
                        }

                        return _id;
                    }
                }
            }
        }

        public Product GetRowById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryGetAllId, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Product product = new Product();
                        if (reader.Read())
                        {
                            product = (new Product()
                            {
                                Id = (int)reader["id"],
                                Name = (string)reader["Name"],
                                Article = (object.Equals(reader["Article"], DBNull.Value) == false
                                                            ? (string)reader["Article"]
                                                            : default(string)),
                                Description = (object.Equals(reader["Description"], DBNull.Value) == false
                                                            ? (string)reader["Description"]
                                                            : default(string))
                            });
                            return product;
                        }
                        else
                        {
                            return null;
                        }

                    }
                }
            }
        }
    }
}
