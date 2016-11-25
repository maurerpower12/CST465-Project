using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MVC465
{
    public class InventoryDBRepository : IDataEntityRepository<Inventory>
    {

        public Inventory Get(int id)
        {
            Inventory cat = new Inventory();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {

                //Perform your database operations
                //Initialize the connection object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;//or .StoredProcedure
                command.CommandText = "SELECT * FROM Product WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();

                //Open the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cat.ID = (int)reader["ID"];
                        cat.ProductName = reader["ProductName"].ToString();
                        cat.ProductDescription = reader["ProductDescription"].ToString();
                        cat.ProductImage = reader["ProductImage"].ToString();
                        cat.ProductCode = reader["ProductCode"].ToString();
                        cat.Price = (decimal)reader["Price"];
                        cat.CategoryID = (int)reader["CategoryID"];
                        cat.Quantity = (int)reader["Quantity"];

                    }
                }
            }
            return cat;
        }
        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {

                //Perform your database operations
                //Initialize the connection object
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;//or .StoredProcedure
                command.CommandText = "DELETE FROM [Product] WHERE ID=@ID";
                command.Parameters.AddWithValue("@ID", id);
                command.Connection.Open();

                //Open the connection
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                    }
                }
            }
        }

        public void Save(Inventory post)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (post.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Product(ProductName,ProductCode,ProductDescription,Price,Quantity, CategoryID) VALUES(@ProductName, @ProductCode, @ProductDescription, @Price, @Quantity, @CategoryID)";

                    }
                    else
                    {
                        command.CommandText = "UPDATE Product SET ProductName=@ProductName, ProductCode=@ProductCode, ProductDescription=@ProductDescription, Price=@Price, Quantity=@Quantity, CategoryID=@CategoryID WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", post.ID);

                    }
                    command.Parameters.AddWithValue("@ProductName", post.ProductName);
                    command.Parameters.AddWithValue("@ProductCode", post.ProductCode);
                    command.Parameters.AddWithValue("@ProductDescription", post.ProductDescription);
                    command.Parameters.AddWithValue("@Price", post.Price);
                    command.Parameters.AddWithValue("@Quantity", post.Quantity);
                    //command.Parameters.AddWithValue("@ProductImage", null);
                    command.Parameters.AddWithValue("@CategoryID", post.CategoryID);


                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<Inventory> GetList()
        {
            List<Inventory> cats = new List<Inventory>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    //Perform your database operations
                    //Initialize the connection object
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Product";
                    command.Connection.Open();

                    //Open the connection
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                Inventory juanc = new Inventory();
                                juanc.ID = (int)reader["ID"];
                                juanc.ProductName = reader["ProductName"].ToString();
                                juanc.ProductDescription = reader["ProductDescription"].ToString();
                                juanc.ProductImage = reader["ProductImage"].ToString();
                                juanc.ProductCode = reader["ProductCode"].ToString();
                                juanc.Price = (decimal)reader["Price"];
                                juanc.CategoryID = (int)(reader["CategoryID"]);
                                juanc.Quantity = (int)reader["Quantity"];
                                cats.Add(juanc);
                            }
                        }
                    }
                }
                return cats;
            }
        }
    }
}